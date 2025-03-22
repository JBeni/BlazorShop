// <copyright file="UserServiceTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Common.Models;
using BlazorShop.Application.Users.Commands;
using BlazorShop.Application.Users.Queries;
using BlazorShop.Domain.Entities;
using BlazorShop.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using System.Security.Claims;

namespace BlazorShop.UnitTests.Infrastructure
{
    /// <summary>
    /// Tests for <see cref="UserService"/> class.
    /// </summary>
    public class UserServiceTests
    {
        private readonly Mock<UserManager<User>> _userManagerMock;
        private readonly Mock<IRoleService> _roleServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IUserClaimsPrincipalFactory<User>> _userClaimsPrincipalFactoryMock;
        private readonly Mock<IAuthorizationService> _authorizationServiceMock;
        private readonly UserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserServiceTests"/> class.
        /// </summary>
        public UserServiceTests()
        {
            var userStore = new Mock<IUserStore<User>>();
            _userManagerMock = new Mock<UserManager<User>>(
                userStore.Object, null, null, null, null, null, null, null, null);

            _roleServiceMock = new Mock<IRoleService>();
            _mapperMock = new Mock<IMapper>();
            _userClaimsPrincipalFactoryMock = new Mock<IUserClaimsPrincipalFactory<User>>();
            _authorizationServiceMock = new Mock<IAuthorizationService>();

            _userService = new UserService(
                _userManagerMock.Object,
                _roleServiceMock.Object,
                _mapperMock.Object,
                _userClaimsPrincipalFactoryMock.Object,
                _authorizationServiceMock.Object);
        }

        [Fact]
        public async Task CreateUserAsync_WithValidCommand_CreatesUser()
        {
            // Arrange
            var command = new CreateUserCommand 
            { 
                Email = "test@example.com",
                UserName = "testuser",
                Password = "Password123!"
            };
            var user = new User { Email = command.Email, UserName = command.UserName };

            _userManagerMock.Setup(x => x.CreateAsync(It.IsAny<User>(), command.Password))
                .ReturnsAsync(IdentityResult.Success);
            _roleServiceMock.Setup(x => x.GetDefaultRole())
                .Returns("User");
            _roleServiceMock.Setup(x => x.SetUserRoleAsync(user, "User"))
                .ReturnsAsync(RequestResponse.Success());

            // Act
            var result = await _userService.CreateUserAsync(command);

            // Assert
            Assert.Equal(RequestResponse.Success(), result);
            _userManagerMock.Verify(x => x.CreateAsync(It.Is<User>(u => 
                u.Email == command.Email && u.UserName == command.UserName), command.Password), Times.Once);
        }

        [Fact]
        public async Task DeleteUserAsync_WhenUserExists_DeletesUser()
        {
            // Arrange
            var userId = 1;
            var user = new User { Id = userId.ToString() };

            _userManagerMock.Setup(x => x.FindByIdAsync(userId.ToString()))
                .ReturnsAsync(user);
            _userManagerMock.Setup(x => x.DeleteAsync(user))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _userService.DeleteUserAsync(userId);

            // Assert
            Assert.Equal(RequestResponse.Success(), result);
            _userManagerMock.Verify(x => x.DeleteAsync(user), Times.Once);
        }

        [Fact]
        public async Task FindUserByEmailAsync_WhenUserExists_ReturnsUser()
        {
            // Arrange
            var email = "test@example.com";
            var user = new User { Email = email };

            _userManagerMock.Setup(x => x.FindByEmailAsync(email))
                .ReturnsAsync(user);

            // Act
            var result = await _userService.FindUserByEmailAsync(email);

            // Assert
            Assert.Equal(user, result);
        }

        [Fact]
        public async Task FindUserByIdAsync_WhenUserExists_ReturnsUser()
        {
            // Arrange
            var userId = 1;
            var user = new User { Id = userId.ToString() };

            _userManagerMock.Setup(x => x.FindByIdAsync(userId.ToString()))
                .ReturnsAsync(user);

            // Act
            var result = await _userService.FindUserByIdAsync(userId);

            // Assert
            Assert.Equal(user, result);
        }

        [Fact]
        public async Task GetUserById_WhenUserExists_ReturnsUserResponse()
        {
            // Arrange
            var query = new GetUserByIdQuery { Id = 1 };
            var user = new User { Id = query.Id.ToString() };
            var userResponse = new UserResponse { Id = query.Id };

            _userManagerMock.Setup(x => x.FindByIdAsync(query.Id.ToString()))
                .ReturnsAsync(user);
            _mapperMock.Setup(x => x.Map<UserResponse>(user))
                .Returns(userResponse);

            // Act
            var result = await _userService.GetUserById(query);

            // Assert
            Assert.Equal(userResponse, result);
        }

        [Fact]
        public async Task GetUserByEmail_WhenUserExists_ReturnsUserResponse()
        {
            // Arrange
            var query = new GetUserByEmailQuery { Email = "test@example.com" };
            var user = new User { Email = query.Email };
            var userResponse = new UserResponse { Email = query.Email };

            _userManagerMock.Setup(x => x.FindByEmailAsync(query.Email))
                .ReturnsAsync(user);
            _mapperMock.Setup(x => x.Map<UserResponse>(user))
                .Returns(userResponse);

            // Act
            var result = await _userService.GetUserByEmail(query);

            // Assert
            Assert.Equal(userResponse, result);
        }

        [Fact]
        public async Task GetUserRoleAsync_ReturnsUserRoles()
        {
            // Arrange
            var user = new User { Id = "1" };
            var roles = new List<string> { "User", "Admin" };

            _roleServiceMock.Setup(x => x.CheckUserRolesAsync(user))
                .ReturnsAsync(roles);

            // Act
            var result = await _userService.GetUserRoleAsync(user);

            // Assert
            Assert.Equal(roles, result);
        }

        [Fact]
        public async Task UpdateUserAsync_WithValidCommand_UpdatesUser()
        {
            // Arrange
            var command = new UpdateUserCommand 
            { 
                Id = 1,
                UserName = "updateduser"
            };
            var user = new User { Id = command.Id.ToString() };

            _userManagerMock.Setup(x => x.FindByIdAsync(command.Id.ToString()))
                .ReturnsAsync(user);
            _userManagerMock.Setup(x => x.UpdateAsync(user))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _userService.UpdateUserAsync(command);

            // Assert
            Assert.Equal(RequestResponse.Success(), result);
            Assert.Equal(command.UserName, user.UserName);
        }

        [Fact]
        public async Task ActivateUserAsync_WithValidCommand_ActivatesUser()
        {
            // Arrange
            var command = new ActivateUserCommand { Id = 1 };
            var user = new User { Id = command.Id.ToString(), IsActive = false };

            _userManagerMock.Setup(x => x.FindByIdAsync(command.Id.ToString()))
                .ReturnsAsync(user);
            _userManagerMock.Setup(x => x.UpdateAsync(user))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _userService.ActivateUserAsync(command);

            // Assert
            Assert.Equal(RequestResponse.Success(), result);
            Assert.True(user.IsActive);
        }

        [Fact]
        public async Task UpdateUserEmailAsync_WithValidCommand_UpdatesEmail()
        {
            // Arrange
            var command = new UpdateUserEmailCommand 
            { 
                Id = 1,
                NewEmail = "new@example.com"
            };
            var user = new User { Id = command.Id.ToString() };

            _userManagerMock.Setup(x => x.FindByIdAsync(command.Id.ToString()))
                .ReturnsAsync(user);
            _userManagerMock.Setup(x => x.UpdateAsync(user))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _userService.UpdateUserEmailAsync(command);

            // Assert
            Assert.Equal(RequestResponse.Success(), result);
            Assert.Equal(command.NewEmail, user.Email);
        }

        [Fact]
        public async Task GetUsers_ReturnsAllUsers()
        {
            // Arrange
            var query = new GetUsersQuery();
            var users = new List<User> 
            { 
                new User { Id = "1", IsActive = true },
                new User { Id = "2", IsActive = true }
            };
            var userResponses = users.Select(u => new UserResponse { Id = int.Parse(u.Id) }).ToList();

            _userManagerMock.Setup(x => x.Users)
                .Returns(users.AsQueryable());
            _mapperMock.Setup(x => x.Map<IEnumerable<UserResponse>>(It.IsAny<IEnumerable<User>>()))
                .Returns(userResponses);

            // Act
            var result = await _userService.GetUsers(query);

            // Assert
            Assert.Equal(userResponses.Count, result.Count());
        }

        [Fact]
        public async Task GetUsersInactive_ReturnsInactiveUsers()
        {
            // Arrange
            var query = new GetUsersInactiveQuery();
            var users = new List<User> 
            { 
                new User { Id = "1", IsActive = false },
                new User { Id = "2", IsActive = false }
            };
            var userResponses = users.Select(u => new UserResponse { Id = int.Parse(u.Id) }).ToList();

            _userManagerMock.Setup(x => x.Users)
                .Returns(users.AsQueryable());
            _mapperMock.Setup(x => x.Map<IEnumerable<UserResponse>>(It.IsAny<IEnumerable<User>>()))
                .Returns(userResponses);

            // Act
            var result = await _userService.GetUsersInactive(query);

            // Assert
            Assert.Equal(userResponses.Count, result.Count());
        }

        [Fact]
        public async Task AssignUserToRoleAsync_WithValidCommand_AssignsRole()
        {
            // Arrange
            var command = new AssignUserToRoleCommand { UserId = 1, Role = "Admin" };
            var user = new User { Id = command.UserId.ToString() };

            _userManagerMock.Setup(x => x.FindByIdAsync(command.UserId.ToString()))
                .ReturnsAsync(user);
            _roleServiceMock.Setup(x => x.SetUserRoleAsync(user, command.Role))
                .ReturnsAsync(RequestResponse.Success());

            // Act
            var result = await _userService.AssignUserToRoleAsync(command);

            // Assert
            Assert.Equal(RequestResponse.Success(), result);
        }

        [Fact]
        public async Task IsInRoleAsync_WhenUserInRole_ReturnsTrue()
        {
            // Arrange
            var userId = 1;
            var role = "Admin";
            var user = new User { Id = userId.ToString() };

            _userManagerMock.Setup(x => x.FindByIdAsync(userId.ToString()))
                .ReturnsAsync(user);
            _userManagerMock.Setup(x => x.IsInRoleAsync(user, role))
                .ReturnsAsync(true);

            // Act
            var result = await _userService.IsInRoleAsync(userId, role);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task AuthorizeAsync_WhenAuthorized_ReturnsTrue()
        {
            // Arrange
            var userId = 1;
            var policy = "TestPolicy";
            var user = new User { Id = userId.ToString() };
            var claimsPrincipal = new ClaimsPrincipal();

            _userManagerMock.Setup(x => x.FindByIdAsync(userId.ToString()))
                .ReturnsAsync(user);
            _userClaimsPrincipalFactoryMock.Setup(x => x.CreateAsync(user))
                .ReturnsAsync(claimsPrincipal);
            _authorizationServiceMock.Setup(x => x.AuthorizeAsync(claimsPrincipal, policy))
                .ReturnsAsync(AuthorizationResult.Success());

            // Act
            var result = await _userService.AuthorizeAsync(userId, policy);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task CreateUserAsync_WhenCreateFails_ThrowsException()
        {
            // Arrange
            var command = new CreateUserCommand 
            { 
                Email = "test@example.com",
                UserName = "testuser",
                Password = "Password123!"
            };
            var errors = new[] { new IdentityError { Description = "User creation failed" } };

            _userManagerMock.Setup(x => x.CreateAsync(It.IsAny<User>(), command.Password))
                .ReturnsAsync(IdentityResult.Failed(errors));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(
                () => _userService.CreateUserAsync(command));
            Assert.Contains("User creation failed", exception.Message);
        }

        [Fact]
        public async Task UpdateUserAsync_WhenUserNotFound_ThrowsException()
        {
            // Arrange
            var command = new UpdateUserCommand { Id = 1 };

            _userManagerMock.Setup(x => x.FindByIdAsync(command.Id.ToString()))
                .ReturnsAsync((User)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(
                () => _userService.UpdateUserAsync(command));
            Assert.Contains("User not found", exception.Message);
        }

        [Fact]
        public async Task DeleteUserAsync_WhenUserNotFound_ThrowsException()
        {
            // Arrange
            var userId = 1;

            _userManagerMock.Setup(x => x.FindByIdAsync(userId.ToString()))
                .ReturnsAsync((User)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(
                () => _userService.DeleteUserAsync(userId));
            Assert.Contains("User not found", exception.Message);
        }
    }
}

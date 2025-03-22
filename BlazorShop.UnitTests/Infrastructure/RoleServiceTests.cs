// <copyright file="RoleServiceTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Common.Models;
using BlazorShop.Application.Roles.Commands;
using BlazorShop.Domain.Entities;
using BlazorShop.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using AutoMapper;

namespace BlazorShop.UnitTests.Infrastructure
{
    /// <summary>
    /// Tests for <see cref="RoleService"/> class.
    /// </summary>
    public class RoleServiceTests
    {
        private readonly Mock<UserManager<User>> _userManagerMock;
        private readonly Mock<RoleManager<Role>> _roleManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly RoleService _roleService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleServiceTests"/> class.
        /// </summary>
        public RoleServiceTests()
        {
            var userStore = new Mock<IUserStore<User>>();
            _userManagerMock = new Mock<UserManager<User>>(
                userStore.Object, null, null, null, null, null, null, null, null);

            var roleStore = new Mock<IRoleStore<Role>>();
            _roleManagerMock = new Mock<RoleManager<Role>>(
                roleStore.Object, null, null, null, null);

            _mapperMock = new Mock<IMapper>();

            _roleService = new RoleService(
                _userManagerMock.Object,
                _roleManagerMock.Object,
                _mapperMock.Object);
        }

        [Fact]
        public async Task CheckUserRolesAsync_WhenUserHasRoles_ReturnsRoles()
        {
            // Arrange
            var user = new User { Id = "1", UserName = "testuser" };
            var roles = new List<string> { "User", "Admin" };

            _userManagerMock.Setup(x => x.GetRolesAsync(user))
                .ReturnsAsync(roles);

            // Act
            var result = await _roleService.CheckUserRolesAsync(user);

            // Assert
            Assert.Equal(roles, result);
            _userManagerMock.Verify(x => x.GetRolesAsync(user), Times.Once);
        }

        [Fact]
        public void GetDefaultRole_ReturnsUserRole()
        {
            // Act
            var result = _roleService.GetDefaultRole();

            // Assert
            Assert.Equal("User", result);
        }

        [Fact]
        public void GetUserRole_ReturnsUserRole()
        {
            // Act
            var result = _roleService.GetUserRole();

            // Assert
            Assert.Equal("User", result);
        }

        [Fact]
        public void GetAdminRole_ReturnsAdminRole()
        {
            // Act
            var result = _roleService.GetAdminRole();

            // Assert
            Assert.Equal("Admin", result);
        }

        [Fact]
        public async Task SetUserRoleAsync_WhenValidRole_AddsRole()
        {
            // Arrange
            var user = new User { Id = "1", UserName = "testuser" };
            var role = "User";

            _userManagerMock.Setup(x => x.AddToRoleAsync(user, role))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _roleService.SetUserRoleAsync(user, role);

            // Assert
            Assert.Equal(RequestResponse.Success(), result);
            _userManagerMock.Verify(x => x.AddToRoleAsync(user, role), Times.Once);
        }

        [Fact]
        public async Task GetRoles_ReturnsAllRoles()
        {
            // Arrange
            var roles = new List<Role> 
            { 
                new Role { Id = "1", Name = "User" },
                new Role { Id = "2", Name = "Admin" }
            };
            var roleResponses = roles.Select(r => new RoleResponse { Id = int.Parse(r.Id), Name = r.Name }).ToList();

            _roleManagerMock.Setup(x => x.Roles)
                .Returns(roles.AsQueryable());
            _mapperMock.Setup(x => x.Map<IEnumerable<RoleResponse>>(It.IsAny<IEnumerable<Role>>()))
                .Returns(roleResponses);

            // Act
            var result = await _roleService.GetRoles();

            // Assert
            Assert.Equal(roleResponses.Count, result.Count());
            _mapperMock.Verify(x => x.Map<IEnumerable<RoleResponse>>(It.IsAny<IEnumerable<Role>>()), Times.Once);
        }

        [Fact]
        public async Task GetRolesForAdmin_ReturnsAdminRoles()
        {
            // Arrange
            var roles = new List<Role> 
            { 
                new Role { Id = "1", Name = "User" },
                new Role { Id = "2", Name = "Admin" }
            };
            var roleResponses = roles.Select(r => new RoleResponse { Id = int.Parse(r.Id), Name = r.Name }).ToList();

            _roleManagerMock.Setup(x => x.Roles)
                .Returns(roles.AsQueryable());
            _mapperMock.Setup(x => x.Map<IEnumerable<RoleResponse>>(It.IsAny<IEnumerable<Role>>()))
                .Returns(roleResponses);

            // Act
            var result = await _roleService.GetRolesForAdmin();

            // Assert
            Assert.Equal(roleResponses.Count, result.Count());
        }

        [Fact]
        public async Task GetRoleById_WhenRoleExists_ReturnsRole()
        {
            // Arrange
            var roleId = 1;
            var role = new Role { Id = roleId.ToString(), Name = "User" };
            var roleResponse = new RoleResponse { Id = roleId, Name = "User" };

            _roleManagerMock.Setup(x => x.FindByIdAsync(roleId.ToString()))
                .ReturnsAsync(role);
            _mapperMock.Setup(x => x.Map<RoleResponse>(role))
                .Returns(roleResponse);

            // Act
            var result = await _roleService.GetRoleById(roleId);

            // Assert
            Assert.Equal(roleResponse.Id, result.Id);
            Assert.Equal(roleResponse.Name, result.Name);
        }

        [Fact]
        public async Task GetRoleByNormalizedName_WhenRoleExists_ReturnsRole()
        {
            // Arrange
            var normalizedName = "USER";
            var role = new Role { Id = "1", Name = "User", NormalizedName = normalizedName };
            var roleResponse = new RoleResponse { Id = 1, Name = "User" };

            _roleManagerMock.Setup(x => x.FindByNameAsync(normalizedName))
                .ReturnsAsync(role);
            _mapperMock.Setup(x => x.Map<RoleResponse>(role))
                .Returns(roleResponse);

            // Act
            var result = await _roleService.GetRoleByNormalizedName(normalizedName);

            // Assert
            Assert.Equal(roleResponse.Id, result.Id);
            Assert.Equal(roleResponse.Name, result.Name);
        }

        [Fact]
        public async Task CreateRoleAsync_WithValidCommand_CreatesRole()
        {
            // Arrange
            var command = new CreateRoleCommand { Name = "NewRole" };
            var role = new Role { Name = command.Name };

            _roleManagerMock.Setup(x => x.CreateAsync(It.IsAny<Role>()))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _roleService.CreateRoleAsync(command);

            // Assert
            Assert.Equal(RequestResponse.Success(), result);
            _roleManagerMock.Verify(x => x.CreateAsync(It.Is<Role>(r => r.Name == command.Name)), Times.Once);
        }

        [Fact]
        public async Task UpdateRoleAsync_WithValidCommand_UpdatesRole()
        {
            // Arrange
            var command = new UpdateRoleCommand { Id = 1, Name = "UpdatedRole" };
            var role = new Role { Id = command.Id.ToString(), Name = "OldName" };

            _roleManagerMock.Setup(x => x.FindByIdAsync(command.Id.ToString()))
                .ReturnsAsync(role);
            _roleManagerMock.Setup(x => x.UpdateAsync(It.IsAny<Role>()))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _roleService.UpdateRoleAsync(command);

            // Assert
            Assert.Equal(RequestResponse.Success(), result);
            Assert.Equal(command.Name, role.Name);
            _roleManagerMock.Verify(x => x.UpdateAsync(role), Times.Once);
        }

        [Fact]
        public async Task DeleteRoleAsync_WhenRoleExists_DeletesRole()
        {
            // Arrange
            var roleId = 1;
            var role = new Role { Id = roleId.ToString(), Name = "User" };

            _roleManagerMock.Setup(x => x.FindByIdAsync(roleId.ToString()))
                .ReturnsAsync(role);
            _roleManagerMock.Setup(x => x.DeleteAsync(role))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _roleService.DeleteRoleAsync(roleId);

            // Assert
            Assert.Equal(RequestResponse.Success(), result);
            _roleManagerMock.Verify(x => x.DeleteAsync(role), Times.Once);
        }

        [Fact]
        public async Task FindRoleByIdAsync_WhenRoleExists_ReturnsRole()
        {
            // Arrange
            var roleId = 1;
            var role = new Role { Id = roleId.ToString(), Name = "User" };

            _roleManagerMock.Setup(x => x.FindByIdAsync(roleId.ToString()))
                .ReturnsAsync(role);

            // Act
            var result = await _roleService.FindRoleByIdAsync(roleId);

            // Assert
            Assert.Equal(role, result);
        }

        [Fact]
        public async Task FindRoleByNameAsync_WhenRoleExists_ReturnsRole()
        {
            // Arrange
            var roleName = "User";
            var role = new Role { Id = "1", Name = roleName };

            _roleManagerMock.Setup(x => x.FindByNameAsync(roleName))
                .ReturnsAsync(role);

            // Act
            var result = await _roleService.FindRoleByNameAsync(roleName);

            // Assert
            Assert.Equal(role, result);
        }

        [Fact]
        public async Task CreateRoleAsync_WhenCreateFails_ThrowsException()
        {
            // Arrange
            var command = new CreateRoleCommand { Name = "NewRole" };
            var errors = new[] { new IdentityError { Description = "Role creation failed" } };

            _roleManagerMock.Setup(x => x.CreateAsync(It.IsAny<Role>()))
                .ReturnsAsync(IdentityResult.Failed(errors));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(
                () => _roleService.CreateRoleAsync(command));
            Assert.Contains("Role creation failed", exception.Message);
        }

        [Fact]
        public async Task UpdateRoleAsync_WhenRoleNotFound_ThrowsException()
        {
            // Arrange
            var command = new UpdateRoleCommand { Id = 1, Name = "UpdatedRole" };

            _roleManagerMock.Setup(x => x.FindByIdAsync(command.Id.ToString()))
                .ReturnsAsync((Role)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(
                () => _roleService.UpdateRoleAsync(command));
            Assert.Contains("Role not found", exception.Message);
        }

        [Fact]
        public async Task DeleteRoleAsync_WhenRoleNotFound_ThrowsException()
        {
            // Arrange
            var roleId = 1;

            _roleManagerMock.Setup(x => x.FindByIdAsync(roleId.ToString()))
                .ReturnsAsync((Role)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(
                () => _roleService.DeleteRoleAsync(roleId));
            Assert.Contains("Role not found", exception.Message);
        }
    }
}

// <copyright file="AccountServiceTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Common.Models;
using BlazorShop.Application.Users.Commands;
using BlazorShop.Domain.Entities;
using BlazorShop.Infrastructure.Identity;
using BlazorShop.Infrastructure.Persistence;
using BlazorShop.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlazorShop.UnitTests.Infrastructure
{
    /// <summary>
    /// Tests for <see cref="BlazorShop.Infrastructure.Services.AccountService"/> class.
    /// </summary>
    public class AccountServiceTests
    {
        private readonly Mock<UserManager<User>> _userManagerMock;
        private readonly Mock<RoleManager<Role>> _roleManagerMock;
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly AccountService _accountService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountServiceTests"/> class.
        /// </summary>
        public AccountServiceTests()
        {
            var userStore = new Mock<IUserStore<User>>();
            _userManagerMock = new Mock<UserManager<User>>(
                userStore.Object, null, null, null, null, null, null, null, null);

            var roleStore = new Mock<IRoleStore<Role>>();
            _roleManagerMock = new Mock<RoleManager<Role>>(
                roleStore.Object, null, null, null, null);

            _configurationMock = new Mock<IConfiguration>();
            _configurationMock.Setup(x => x["JwtSettings:Secret"]).Returns("your-256-bit-secret");
            _configurationMock.Setup(x => x["JwtSettings:Issuer"]).Returns("blazorshop");
            _configurationMock.Setup(x => x["JwtSettings:Audience"]).Returns("blazorshop");

            _accountService = new AccountService(
                _userManagerMock.Object,
                _roleManagerMock.Object,
                _configurationMock.Object);
        }

        [Fact]
        public async Task ChangePasswordUserAsync_WhenUserNotFound_ThrowsException()
        {
            // Arrange
            var command = new ChangePasswordCommand { UserId = "1" };
            _userManagerMock.Setup(x => x.FindByIdAsync(It.IsAny<string>()))
                .ReturnsAsync((User)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(
                () => _accountService.ChangePasswordUserAsync(command));
            Assert.Contains("User not found", exception.Message);
        }

        [Fact]
        public async Task ChangePasswordUserAsync_WhenOldPasswordInvalid_ThrowsException()
        {
            // Arrange
            var user = new User { Id = "1", UserName = "test" };
            var command = new ChangePasswordCommand 
            { 
                UserId = "1",
                OldPassword = "oldPass",
                NewPassword = "newPass",
                ConfirmNewPassword = "newPass"
            };

            _userManagerMock.Setup(x => x.FindByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(user);
            _userManagerMock.Setup(x => x.CheckPasswordAsync(user, command.OldPassword))
                .ReturnsAsync(false);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(
                () => _accountService.ChangePasswordUserAsync(command));
            Assert.Contains("Invalid old password", exception.Message);
        }

        [Fact]
        public async Task ChangePasswordUserAsync_WhenPasswordsDontMatch_ThrowsException()
        {
            // Arrange
            var user = new User { Id = "1", UserName = "test" };
            var command = new ChangePasswordCommand 
            { 
                UserId = "1",
                OldPassword = "oldPass",
                NewPassword = "newPass",
                ConfirmNewPassword = "differentPass"
            };

            _userManagerMock.Setup(x => x.FindByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(user);
            _userManagerMock.Setup(x => x.CheckPasswordAsync(user, command.OldPassword))
                .ReturnsAsync(true);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(
                () => _accountService.ChangePasswordUserAsync(command));
            Assert.Contains("Passwords do not match", exception.Message);
        }

        [Fact]
        public async Task ChangePasswordUserAsync_WhenValid_ChangesPassword()
        {
            // Arrange
            var user = new User { Id = "1", UserName = "test" };
            var command = new ChangePasswordCommand 
            { 
                UserId = "1",
                OldPassword = "oldPass",
                NewPassword = "newPass",
                ConfirmNewPassword = "newPass"
            };

            _userManagerMock.Setup(x => x.FindByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(user);
            _userManagerMock.Setup(x => x.CheckPasswordAsync(user, command.OldPassword))
                .ReturnsAsync(true);
            _userManagerMock.Setup(x => x.ChangePasswordAsync(user, command.OldPassword, command.NewPassword))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _accountService.ChangePasswordUserAsync(command);

            // Assert
            Assert.Equal(RequestResponse.Success(), result);
            _userManagerMock.Verify(x => x.ChangePasswordAsync(user, command.OldPassword, command.NewPassword), Times.Once);
        }

        [Fact]
        public async Task ChangePasswordUserAsync_WhenChangePasswordFails_ThrowsException()
        {
            // Arrange
            var user = new User { Id = "1", UserName = "test" };
            var command = new ChangePasswordCommand 
            { 
                UserId = "1",
                OldPassword = "oldPass",
                NewPassword = "newPass",
                ConfirmNewPassword = "newPass"
            };

            _userManagerMock.Setup(x => x.FindByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(user);
            _userManagerMock.Setup(x => x.CheckPasswordAsync(user, command.OldPassword))
                .ReturnsAsync(true);
            _userManagerMock.Setup(x => x.ChangePasswordAsync(user, command.OldPassword, command.NewPassword))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Password change failed" }));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(
                () => _accountService.ChangePasswordUserAsync(command));
            Assert.Contains("Password change failed", exception.Message);
        }

        [Fact]
        public async Task GenerateJwtToken_ReturnsValidToken()
        {
            // Arrange
            var user = new User 
            { 
                Id = "1", 
                UserName = "testuser",
                Email = "test@example.com"
            };
            var roles = new List<string> { "User" };

            _userManagerMock.Setup(x => x.GetRolesAsync(user))
                .ReturnsAsync(roles);

            // Act
            var token = await _accountService.GenerateJwtToken(user);

            // Assert
            Assert.NotNull(token);
            Assert.NotEmpty(token);
        }

        [Fact]
        public async Task ValidateJwtToken_WithValidToken_ReturnsUserId()
        {
            // Arrange
            var user = new User 
            { 
                Id = "1", 
                UserName = "testuser",
                Email = "test@example.com"
            };
            var roles = new List<string> { "User" };

            _userManagerMock.Setup(x => x.GetRolesAsync(user))
                .ReturnsAsync(roles);

            var token = await _accountService.GenerateJwtToken(user);

            // Act
            var result = _accountService.ValidateJwtToken(token);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("invalid-token")]
        public void ValidateJwtToken_WithInvalidToken_ReturnsNull(string token)
        {
            // Act
            var result = _accountService.ValidateJwtToken(token);

            // Assert
            Assert.Null(result);
        }
    }
}

// <copyright file="AccountCommandHandlersTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Common.Interfaces;
using BlazorShop.Application.Common.Models;
using BlazorShop.Application.Handlers.Commands.AccountHandler;
using BlazorShop.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace BlazorShop.UnitTests.Application.Handlers.Commands.AccountHandler
{
    /// <summary>
    /// Tests for Account command handlers.
    /// </summary>
    public class AccountCommandHandlersTests
    {
        private readonly Mock<UserManager<User>> _userManagerMock;
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly Mock<ILogger<LoginUserCommandHandler>> _loginLoggerMock;
        private readonly Mock<ILogger<RegisterUserCommandHandler>> _registerLoggerMock;
        private readonly Mock<ILogger<ChangePasswordCommandHandler>> _changePasswordLoggerMock;
        private readonly Mock<ILogger<DeleteUserCommandHandler>> _deleteUserLoggerMock;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountCommandHandlersTests"/> class.
        /// </summary>
        public AccountCommandHandlersTests()
        {
            var userStore = new Mock<IUserStore<User>>();
            _userManagerMock = new Mock<UserManager<User>>(
                userStore.Object, null, null, null, null, null, null, null, null);
            _configurationMock = new Mock<IConfiguration>();
            _loginLoggerMock = new Mock<ILogger<LoginUserCommandHandler>>();
            _registerLoggerMock = new Mock<ILogger<RegisterUserCommandHandler>>();
            _changePasswordLoggerMock = new Mock<ILogger<ChangePasswordCommandHandler>>();
            _deleteUserLoggerMock = new Mock<ILogger<DeleteUserCommandHandler>>();

            _configurationMock.Setup(x => x["JwtSettings:Key"]).Returns("YourSecretKeyHere12345678901234567890");
            _configurationMock.Setup(x => x["JwtSettings:Issuer"]).Returns("BlazorShop");
            _configurationMock.Setup(x => x["JwtSettings:Audience"]).Returns("BlazorShopUser");
            _configurationMock.Setup(x => x["JwtSettings:DurationInMinutes"]).Returns("60");
        }

        [Fact]
        public async Task LoginUserCommandHandler_ValidCredentials_ReturnsSuccessResponse()
        {
            // Arrange
            var command = new LoginUserCommand
            {
                Email = "test@example.com",
                Password = "Password123!"
            };

            var user = new User { Id = "1", Email = command.Email };

            _userManagerMock.Setup(x => x.FindByEmailAsync(command.Email))
                .ReturnsAsync(user);
            _userManagerMock.Setup(x => x.CheckPasswordAsync(user, command.Password))
                .ReturnsAsync(true);
            _userManagerMock.Setup(x => x.GetRolesAsync(user))
                .ReturnsAsync(new List<string> { "User" });

            var handler = new LoginUserCommandHandler(_userManagerMock.Object, _configurationMock.Object, _loginLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Succeeded);
            Assert.NotNull(result.Data);
            Assert.NotEmpty(result.Data.Token);
            Assert.Equal(user.Email, result.Data.Email);
        }

        [Fact]
        public async Task LoginUserCommandHandler_InvalidCredentials_ReturnsFailureResponse()
        {
            // Arrange
            var command = new LoginUserCommand
            {
                Email = "test@example.com",
                Password = "WrongPassword"
            };

            var user = new User { Email = command.Email };

            _userManagerMock.Setup(x => x.FindByEmailAsync(command.Email))
                .ReturnsAsync(user);
            _userManagerMock.Setup(x => x.CheckPasswordAsync(user, command.Password))
                .ReturnsAsync(false);

            var handler = new LoginUserCommandHandler(_userManagerMock.Object, _configurationMock.Object, _loginLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Contains("Invalid credentials", result.Error);
        }

        [Fact]
        public async Task RegisterUserCommandHandler_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var command = new RegisterUserCommand
            {
                Email = "new@example.com",
                Password = "Password123!",
                ConfirmPassword = "Password123!"
            };

            _userManagerMock.Setup(x => x.FindByEmailAsync(command.Email))
                .ReturnsAsync((User)null);
            _userManagerMock.Setup(x => x.CreateAsync(It.IsAny<User>(), command.Password))
                .ReturnsAsync(IdentityResult.Success);
            _userManagerMock.Setup(x => x.AddToRoleAsync(It.IsAny<User>(), "User"))
                .ReturnsAsync(IdentityResult.Success);

            var handler = new RegisterUserCommandHandler(_userManagerMock.Object, _registerLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Succeeded);
            _userManagerMock.Verify(x => x.CreateAsync(It.IsAny<User>(), command.Password), Times.Once);
            _userManagerMock.Verify(x => x.AddToRoleAsync(It.IsAny<User>(), "User"), Times.Once);
        }

        [Fact]
        public async Task RegisterUserCommandHandler_UserAlreadyExists_ReturnsFailureResponse()
        {
            // Arrange
            var command = new RegisterUserCommand
            {
                Email = "existing@example.com",
                Password = "Password123!",
                ConfirmPassword = "Password123!"
            };

            _userManagerMock.Setup(x => x.FindByEmailAsync(command.Email))
                .ReturnsAsync(new User());

            var handler = new RegisterUserCommandHandler(_userManagerMock.Object, _registerLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Contains("User already exists", result.Error);
            _userManagerMock.Verify(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task ChangePasswordCommandHandler_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var command = new ChangePasswordCommand
            {
                Email = "test@example.com",
                OldPassword = "OldPassword123!",
                NewPassword = "NewPassword123!",
                ConfirmNewPassword = "NewPassword123!"
            };

            var user = new User { Email = command.Email };

            _userManagerMock.Setup(x => x.FindByEmailAsync(command.Email))
                .ReturnsAsync(user);
            _userManagerMock.Setup(x => x.ChangePasswordAsync(user, command.OldPassword, command.NewPassword))
                .ReturnsAsync(IdentityResult.Success);

            var handler = new ChangePasswordCommandHandler(_userManagerMock.Object, _changePasswordLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Succeeded);
            _userManagerMock.Verify(x => x.ChangePasswordAsync(user, command.OldPassword, command.NewPassword), Times.Once);
        }

        [Fact]
        public async Task ChangePasswordCommandHandler_UserNotFound_ReturnsFailureResponse()
        {
            // Arrange
            var command = new ChangePasswordCommand
            {
                Email = "nonexistent@example.com",
                OldPassword = "OldPassword123!",
                NewPassword = "NewPassword123!",
                ConfirmNewPassword = "NewPassword123!"
            };

            _userManagerMock.Setup(x => x.FindByEmailAsync(command.Email))
                .ReturnsAsync((User)null);

            var handler = new ChangePasswordCommandHandler(_userManagerMock.Object, _changePasswordLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Contains("User not found", result.Error);
        }

        [Fact]
        public async Task DeleteUserCommandHandler_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var command = new DeleteUserCommand { Email = "test@example.com" };
            var user = new User { Email = command.Email };

            _userManagerMock.Setup(x => x.FindByEmailAsync(command.Email))
                .ReturnsAsync(user);
            _userManagerMock.Setup(x => x.DeleteAsync(user))
                .ReturnsAsync(IdentityResult.Success);

            var handler = new DeleteUserCommandHandler(_userManagerMock.Object, _deleteUserLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Succeeded);
            _userManagerMock.Verify(x => x.DeleteAsync(user), Times.Once);
        }

        [Fact]
        public async Task DeleteUserCommandHandler_UserNotFound_ReturnsFailureResponse()
        {
            // Arrange
            var command = new DeleteUserCommand { Email = "nonexistent@example.com" };

            _userManagerMock.Setup(x => x.FindByEmailAsync(command.Email))
                .ReturnsAsync((User)null);

            var handler = new DeleteUserCommandHandler(_userManagerMock.Object, _deleteUserLoggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Contains("User not found", result.Error);
            _userManagerMock.Verify(x => x.DeleteAsync(It.IsAny<User>()), Times.Never);
        }
    }
} 
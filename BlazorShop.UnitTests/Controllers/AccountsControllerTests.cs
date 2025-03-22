// <copyright file="AccountsControllerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Controllers
{
    /// <summary>
    /// Tests for <see cref="AccountsController"/> class.
    /// </summary>
    public class AccountsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly AccountsController _controller;

        public AccountsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new AccountsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Login_ValidCredentials_ReturnsOkResult()
        {
            // Arrange
            var command = new LoginCommand 
            { 
                Email = "test@example.com",
                Password = "Password123!"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<LoginCommand>(), default))
                .ReturnsAsync(new AuthenticationResult { Success = true, Token = "test-token" });

            // Act
            var result = await _controller.Login(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var authResult = Assert.IsType<AuthenticationResult>(okResult.Value);
            Assert.True(authResult.Success);
            Assert.NotNull(authResult.Token);
        }

        [Fact]
        public async Task Register_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new RegisterCommand 
            { 
                Email = "test@example.com",
                Password = "Password123!",
                ConfirmPassword = "Password123!"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<RegisterCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.Register(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task ForgotPassword_ValidEmail_ReturnsOkResult()
        {
            // Arrange
            var command = new ForgotPasswordCommand { Email = "test@example.com" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<ForgotPasswordCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.ForgotPassword(command);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task ResetPassword_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new ResetPasswordCommand 
            { 
                Email = "test@example.com",
                Token = "reset-token",
                Password = "NewPassword123!",
                ConfirmPassword = "NewPassword123!"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<ResetPasswordCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.ResetPassword(command);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task ChangePassword_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new ChangePasswordCommand 
            { 
                UserId = 1,
                CurrentPassword = "CurrentPass123!",
                NewPassword = "NewPass123!",
                ConfirmNewPassword = "NewPass123!"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<ChangePasswordCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.ChangePassword(command);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}

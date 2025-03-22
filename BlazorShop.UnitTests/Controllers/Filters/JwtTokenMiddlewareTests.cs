// <copyright file="JwtTokenMiddlewareTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Controllers.Filters
{
    /// <summary>
    /// Tests for <see cref="JwtTokenMiddleware"/> class.
    /// </summary>
    public class JwtTokenMiddlewareTests
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly Mock<ILogger<JwtTokenMiddleware>> _loggerMock;
        private readonly JwtTokenMiddleware _middleware;
        private readonly RequestDelegate _next;

        public JwtTokenMiddlewareTests()
        {
            _userServiceMock = new Mock<IUserService>();
            _loggerMock = new Mock<ILogger<JwtTokenMiddleware>>();
            _next = (HttpContext context) => Task.CompletedTask;
            _middleware = new JwtTokenMiddleware(_next, _userServiceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task InvokeAsync_WithValidToken_SetsUser()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var token = "valid-jwt-token";
            var userId = 1;
            context.Request.Headers["Authorization"] = $"Bearer {token}";

            _userServiceMock.Setup(x => x.ValidateJwtTokenAsync(token))
                .ReturnsAsync(userId);

            // Act
            await _middleware.InvokeAsync(context);

            // Assert
            Assert.Equal(userId.ToString(), context.User.Identity.Name);
            _userServiceMock.Verify(x => x.ValidateJwtTokenAsync(token), Times.Once);
        }

        [Fact]
        public async Task InvokeAsync_WithInvalidToken_DoesNotSetUser()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var token = "invalid-jwt-token";
            context.Request.Headers["Authorization"] = $"Bearer {token}";

            _userServiceMock.Setup(x => x.ValidateJwtTokenAsync(token))
                .ReturnsAsync((int?)null);

            // Act
            await _middleware.InvokeAsync(context);

            // Assert
            Assert.Null(context.User.Identity.Name);
            _userServiceMock.Verify(x => x.ValidateJwtTokenAsync(token), Times.Once);
        }

        [Fact]
        public async Task InvokeAsync_WithoutToken_DoesNotValidateToken()
        {
            // Arrange
            var context = new DefaultHttpContext();

            // Act
            await _middleware.InvokeAsync(context);

            // Assert
            Assert.Null(context.User.Identity.Name);
            _userServiceMock.Verify(x => x.ValidateJwtTokenAsync(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task InvokeAsync_WithMalformedToken_DoesNotValidateToken()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Request.Headers["Authorization"] = "malformed-token";

            // Act
            await _middleware.InvokeAsync(context);

            // Assert
            Assert.Null(context.User.Identity.Name);
            _userServiceMock.Verify(x => x.ValidateJwtTokenAsync(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task InvokeAsync_WithException_LogsErrorAndContinues()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var token = "valid-jwt-token";
            var exception = new Exception("Test exception");
            context.Request.Headers["Authorization"] = $"Bearer {token}";

            _userServiceMock.Setup(x => x.ValidateJwtTokenAsync(token))
                .ThrowsAsync(exception);

            // Act
            await _middleware.InvokeAsync(context);

            // Assert
            _loggerMock.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    exception,
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);
        }

        [Fact]
        public async Task InvokeAsync_CallsNextMiddleware()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var nextCalled = false;
            var next = new RequestDelegate(context =>
            {
                nextCalled = true;
                return Task.CompletedTask;
            });
            var middleware = new JwtTokenMiddleware(next, _userServiceMock.Object, _loggerMock.Object);

            // Act
            await middleware.InvokeAsync(context);

            // Assert
            Assert.True(nextCalled);
        }
    }
}

// <copyright file="ApiExceptionFilterAttributeTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Controllers.Filters
{
    /// <summary>
    /// Tests for <see cref="ApiExceptionFilterAttribute"/> class.
    /// </summary>
    public class ApiExceptionFilterAttributeTests
    {
        private readonly ApiExceptionFilterAttribute _filter;
        private readonly Mock<ILogger<ApiExceptionFilterAttribute>> _loggerMock;

        public ApiExceptionFilterAttributeTests()
        {
            _loggerMock = new Mock<ILogger<ApiExceptionFilterAttribute>>();
            _filter = new ApiExceptionFilterAttribute(_loggerMock.Object);
        }

        [Fact]
        public void OnException_ValidationException_ReturnsBadRequest()
        {
            // Arrange
            var exception = new ValidationException(new[] 
            { 
                new ValidationFailure("TestProperty", "Test error message") 
            });
            var context = CreateExceptionContext(exception);

            // Act
            _filter.OnException(context);

            // Assert
            var result = Assert.IsType<BadRequestObjectResult>(context.Result);
            var errors = Assert.IsType<Dictionary<string, string[]>>(result.Value);
            Assert.Contains("TestProperty", errors.Keys);
        }

        [Fact]
        public void OnException_NotFoundException_ReturnsNotFound()
        {
            // Arrange
            var exception = new NotFoundException("Test entity", "1");
            var context = CreateExceptionContext(exception);

            // Act
            _filter.OnException(context);

            // Assert
            var result = Assert.IsType<NotFoundObjectResult>(context.Result);
            Assert.Equal("Test entity with id '1' was not found.", result.Value);
        }

        [Fact]
        public void OnException_UnauthorizedAccessException_ReturnsUnauthorized()
        {
            // Arrange
            var exception = new UnauthorizedAccessException("Unauthorized access");
            var context = CreateExceptionContext(exception);

            // Act
            _filter.OnException(context);

            // Assert
            var result = Assert.IsType<UnauthorizedObjectResult>(context.Result);
            Assert.Equal("Unauthorized access", result.Value);
        }

        [Fact]
        public void OnException_ForbiddenAccessException_ReturnsForbidden()
        {
            // Arrange
            var exception = new ForbiddenAccessException("Forbidden access");
            var context = CreateExceptionContext(exception);

            // Act
            _filter.OnException(context);

            // Assert
            var result = Assert.IsType<ObjectResult>(context.Result);
            Assert.Equal(StatusCodes.Status403Forbidden, result.StatusCode);
            Assert.Equal("Forbidden access", result.Value);
        }

        [Fact]
        public void OnException_UnhandledException_ReturnsInternalServerError()
        {
            // Arrange
            var exception = new Exception("Unexpected error");
            var context = CreateExceptionContext(exception);

            // Act
            _filter.OnException(context);

            // Assert
            var result = Assert.IsType<ObjectResult>(context.Result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result.StatusCode);
            Assert.Equal("An error occurred while processing your request.", result.Value);
        }

        [Fact]
        public void OnException_LogsException()
        {
            // Arrange
            var exception = new Exception("Test exception");
            var context = CreateExceptionContext(exception);

            // Act
            _filter.OnException(context);

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

        private static ExceptionContext CreateExceptionContext(Exception exception)
        {
            var actionContext = new ActionContext
            {
                HttpContext = new DefaultHttpContext(),
                RouteData = new RouteData(),
                ActionDescriptor = new ActionDescriptor()
            };

            return new ExceptionContext(actionContext, new List<IFilterMetadata>())
            {
                Exception = exception
            };
        }
    }
}

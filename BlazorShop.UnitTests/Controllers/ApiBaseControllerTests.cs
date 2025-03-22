// <copyright file="ApiBaseControllerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Controllers
{
    /// <summary>
    /// Tests for <see cref="ApiBaseController"/> class.
    /// </summary>
    public class ApiBaseControllerTests
    {
        private readonly ApiBaseController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiBaseControllerTests"/> class.
        /// </summary>
        public ApiBaseControllerTests()
        {
            _controller = new TestApiController();
        }

        /// <summary>
        /// A test for <see cref="ApiBaseController(IMediator)"/> method.
        /// </summary>
        [Fact]
        public void Mediator_Property_Should_Return_IMediator_Instance()
        {
        }

        [Fact]
        public void Ok_WithValue_ReturnsOkObjectResult()
        {
            // Arrange
            var value = "test value";

            // Act
            var result = _controller.Ok(value);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(value, okResult.Value);
        }

        [Fact]
        public void Ok_WithoutValue_ReturnsOkResult()
        {
            // Act
            var result = _controller.Ok();

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void BadRequest_WithError_ReturnsBadRequestObjectResult()
        {
            // Arrange
            var error = "error message";

            // Act
            var result = _controller.BadRequest(error);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(error, badRequestResult.Value);
        }

        [Fact]
        public void NotFound_WithMessage_ReturnsNotFoundObjectResult()
        {
            // Arrange
            var message = "not found message";

            // Act
            var result = _controller.NotFound(message);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(message, notFoundResult.Value);
        }

        [Fact]
        public void Unauthorized_WithMessage_ReturnsUnauthorizedObjectResult()
        {
            // Arrange
            var message = "unauthorized message";

            // Act
            var result = _controller.Unauthorized(message);

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
            Assert.Equal(message, unauthorizedResult.Value);
        }

        [Fact]
        public void NoContent_ReturnsNoContentResult()
        {
            // Act
            var result = _controller.NoContent();

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Created_WithLocationAndValue_ReturnsCreatedResult()
        {
            // Arrange
            var location = "api/resource/1";
            var value = new { Id = 1, Name = "Test" };

            // Act
            var result = _controller.Created(location, value);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.Equal(location, createdResult.Location);
            Assert.Equal(value, createdResult.Value);
        }

        private class TestApiController : ApiBaseController
        {
            // Test implementation of ApiBaseController
        }
    }
}

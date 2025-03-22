// <copyright file="HomeControllerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Controllers
{
    /// <summary>
    /// Tests for <see cref="HomeController"/> class.
    /// </summary>
    public class HomeControllerTests
    {
        private readonly Mock<ILogger<HomeController>> _loggerMock;
        private readonly HomeController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeControllerTests"/> class.
        /// </summary>
        public HomeControllerTests()
        {
            _loggerMock = new Mock<ILogger<HomeController>>();
            _controller = new HomeController(_loggerMock.Object);
        }

        [Fact]
        public void Index_ReturnsViewResult()
        {
            // Act
            var result = _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName); // Default view
        }

        [Fact]
        public void Privacy_ReturnsViewResult()
        {
            // Act
            var result = _controller.Privacy();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName); // Default view
        }

        [Fact]
        public void Error_ReturnsViewResultWithErrorViewModel()
        {
            // Arrange
            var expectedRequestId = "TestRequestId";
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
            Activity.Current = new Activity("TestActivity").SetParentId(expectedRequestId);

            // Act
            var result = _controller.Error();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ErrorViewModel>(viewResult.Model);
            Assert.Equal(expectedRequestId, model.RequestId);
        }

        [Fact]
        public void Error_WithoutRequestId_ReturnsViewResultWithShowRequestIdFalse()
        {
            // Arrange
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
            Activity.Current = null;

            // Act
            var result = _controller.Error();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ErrorViewModel>(viewResult.Model);
            Assert.False(model.ShowRequestId);
        }

        [Fact]
        public void Error_WithTraceIdentifier_UsesHttpContextTraceIdentifier()
        {
            // Arrange
            var expectedRequestId = "TestTraceIdentifier";
            var httpContext = new DefaultHttpContext();
            httpContext.TraceIdentifier = expectedRequestId;
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };

            // Act
            var result = _controller.Error();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ErrorViewModel>(viewResult.Model);
            Assert.Equal(expectedRequestId, model.RequestId);
        }

        [Fact]
        public void Error_LogsError()
        {
            // Arrange
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };

            // Act
            _controller.Error();

            // Assert
            _loggerMock.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);
        }
    }
}

// <copyright file="RequestLoggerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Common.Behaviours;

namespace BlazorShop.UnitTests.Application.Behaviours
{
    /// <summary>
    /// Tests for <see cref=""/> class.
    /// </summary>
    public class RequestLoggerTests
    {
        private Mock<ILogger<CreateTodoItemCommand>> _logger = null!;
        private Mock<ICurrentUserService> _currentUserService = null!;
        private Mock<IUserService> _identityService = null!;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestLoggerTests"/> class.
        /// </summary>
        public RequestLoggerTests()
        {
            _logger = new Mock<ILogger<CreateTodoItemCommand>>();
            _currentUserService = new Mock<ICurrentUserService>();
            _identityService = new Mock<IUserService>();
        }

        [Fact]
        public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
        {
            _currentUserService.Setup(x => x.UserId).Returns(1);

            var requestLogger = new LoggingBehaviour<CreateTodoItemCommand>(_logger.Object, _currentUserService.Object, _identityService.Object);

            await requestLogger.Process(new CreateTodoItemCommand { ListId = 1, Title = "title" }, new CancellationToken());

            _identityService.Verify(i => i.FindUserByIdAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
        {
            var requestLogger = new LoggingBehaviour<CreateTodoItemCommand>(_logger.Object, _currentUserService.Object, _identityService.Object);

            await requestLogger.Process(new CreateTodoItemCommand { ListId = 1, Title = "title" }, new CancellationToken());

            _identityService.Verify(i => i.FindUserByIdAsync(It.IsAny<int>()), Times.Never);
        }
    }
}

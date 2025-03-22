// <copyright file="SubscribersControllerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Controllers
{
    /// <summary>
    /// Tests for <see cref="SubscribersController"/> class.
    /// </summary>
    public class SubscribersControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly SubscribersController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscribersControllerTests"/> class.
        /// </summary>
        public SubscribersControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new SubscribersController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateSubscriber_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new CreateSubscriberCommand 
            { 
                Email = "test@example.com",
                Name = "Test User",
                Status = "Active"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateSubscriberCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.CreateSubscriber(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
            _mediatorMock.Verify(m => m.Send(It.IsAny<CreateSubscriberCommand>(), default), Times.Once);
        }

        [Fact]
        public async Task GetSubscriberById_ExistingSubscriber_ReturnsOkResult()
        {
            // Arrange
            var subscriberId = 1;
            var subscriberDto = new SubscriberDto 
            { 
                Id = subscriberId, 
                Email = "test@example.com",
                Name = "Test User"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetSubscriberByIdQuery>(), default))
                .ReturnsAsync(subscriberDto);

            // Act
            var result = await _controller.GetSubscriberById(subscriberId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedSubscriber = Assert.IsType<SubscriberDto>(okResult.Value);
            Assert.Equal(subscriberId, returnedSubscriber.Id);
            _mediatorMock.Verify(m => m.Send(It.Is<GetSubscriberByIdQuery>(q => q.Id == subscriberId), default), Times.Once);
        }

        [Fact]
        public async Task GetSubscribers_ReturnsListOfSubscribers()
        {
            // Arrange
            var subscribers = new List<SubscriberDto> 
            { 
                new SubscriberDto { Id = 1, Email = "user1@example.com", Name = "User 1" },
                new SubscriberDto { Id = 2, Email = "user2@example.com", Name = "User 2" }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetSubscribersQuery>(), default))
                .ReturnsAsync(subscribers);

            // Act
            var result = await _controller.GetSubscribers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedSubscribers = Assert.IsType<List<SubscriberDto>>(okResult.Value);
            Assert.Equal(2, returnedSubscribers.Count);
            _mediatorMock.Verify(m => m.Send(It.IsAny<GetSubscribersQuery>(), default), Times.Once);
        }

        [Fact]
        public async Task GetSubscriberByEmail_ExistingEmail_ReturnsOkResult()
        {
            // Arrange
            var email = "test@example.com";
            var subscriberDto = new SubscriberDto 
            { 
                Id = 1, 
                Email = email,
                Name = "Test User"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetSubscriberByEmailQuery>(), default))
                .ReturnsAsync(subscriberDto);

            // Act
            var result = await _controller.GetSubscriberByEmail(email);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedSubscriber = Assert.IsType<SubscriberDto>(okResult.Value);
            Assert.Equal(email, returnedSubscriber.Email);
            _mediatorMock.Verify(m => m.Send(It.Is<GetSubscriberByEmailQuery>(q => q.Email == email), default), Times.Once);
        }

        [Fact]
        public async Task UpdateSubscriber_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new UpdateSubscriberCommand 
            { 
                Id = 1,
                Name = "Updated User",
                Status = "Active"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateSubscriberCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.UpdateSubscriber(command);

            // Assert
            Assert.IsType<OkResult>(result);
            _mediatorMock.Verify(m => m.Send(command, default), Times.Once);
        }

        [Fact]
        public async Task DeleteSubscriber_ExistingSubscriber_ReturnsOkResult()
        {
            // Arrange
            var subscriberId = 1;
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteSubscriberCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.DeleteSubscriber(subscriberId);

            // Assert
            Assert.IsType<OkResult>(result);
            _mediatorMock.Verify(m => m.Send(It.Is<DeleteSubscriberCommand>(c => c.Id == subscriberId), default), Times.Once);
        }

        [Fact]
        public async Task GetSubscriber_NonExistingSubscriber_ReturnsNotFound()
        {
            // Arrange
            var subscriberId = 999;
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetSubscriberByIdQuery>(), default))
                .ReturnsAsync((SubscriberDto)null);

            // Act
            var result = await _controller.GetSubscriberById(subscriberId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CreateSubscriber_InvalidCommand_ReturnsBadRequest()
        {
            // Arrange
            var command = new CreateSubscriberCommand(); // Invalid command with no data
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateSubscriberCommand>(), default))
                .ReturnsAsync(Result.Failure("Invalid data"));

            // Act
            var result = await _controller.CreateSubscriber(command);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.NotNull(badRequestResult.Value);
        }

        [Fact]
        public async Task GetSubscriberByEmail_NonExistingEmail_ReturnsNotFound()
        {
            // Arrange
            var email = "nonexistent@example.com";
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetSubscriberByEmailQuery>(), default))
                .ReturnsAsync((SubscriberDto)null);

            // Act
            var result = await _controller.GetSubscriberByEmail(email);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}

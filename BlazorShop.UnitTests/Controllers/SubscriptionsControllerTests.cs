// <copyright file="SubscriptionsControllerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Controllers
{
    /// <summary>
    /// Tests for <see cref="SubscriptionsController"/> class.
    /// </summary>
    public class SubscriptionsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly SubscriptionsController _controller;

        public SubscriptionsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new SubscriptionsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateSubscription_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new CreateSubscriptionCommand 
            { 
                UserId = 1,
                PlanType = "Premium",
                StartDate = DateTime.UtcNow
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateSubscriptionCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.CreateSubscription(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task GetSubscriptionById_ExistingSubscription_ReturnsOkResult()
        {
            // Arrange
            var subscriptionId = 1;
            var subscriptionDto = new SubscriptionDto { Id = subscriptionId, UserId = 1 };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetSubscriptionByIdQuery>(), default))
                .ReturnsAsync(subscriptionDto);

            // Act
            var result = await _controller.GetSubscriptionById(subscriptionId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedSubscription = Assert.IsType<SubscriptionDto>(okResult.Value);
            Assert.Equal(subscriptionId, returnedSubscription.Id);
        }

        [Fact]
        public async Task GetSubscriptions_ReturnsListOfSubscriptions()
        {
            // Arrange
            var subscriptions = new List<SubscriptionDto> 
            { 
                new SubscriptionDto { Id = 1, UserId = 1 },
                new SubscriptionDto { Id = 2, UserId = 2 }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetSubscriptionsQuery>(), default))
                .ReturnsAsync(subscriptions);

            // Act
            var result = await _controller.GetSubscriptions();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedSubscriptions = Assert.IsType<List<SubscriptionDto>>(okResult.Value);
            Assert.Equal(2, returnedSubscriptions.Count);
        }

        [Fact]
        public async Task UpdateSubscription_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new UpdateSubscriptionCommand 
            { 
                Id = 1,
                PlanType = "Premium Plus"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateSubscriptionCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.UpdateSubscription(command);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task CancelSubscription_ExistingSubscription_ReturnsOkResult()
        {
            // Arrange
            var subscriptionId = 1;
            _mediatorMock.Setup(m => m.Send(It.IsAny<CancelSubscriptionCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.CancelSubscription(subscriptionId);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}

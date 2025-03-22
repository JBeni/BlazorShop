// <copyright file="OrdersControllerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Controllers
{
    /// <summary>
    /// Tests for <see cref="OrdersController"/> class.
    /// </summary>
    public class OrdersControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly OrdersController _controller;

        public OrdersControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new OrdersController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateOrder_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new CreateOrderCommand 
            { 
                UserId = 1,
                TotalAmount = 199.99m,
                Status = "Pending"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateOrderCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.CreateOrder(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task GetOrderById_ExistingOrder_ReturnsOkResult()
        {
            // Arrange
            var orderId = 1;
            var orderDto = new OrderDto { Id = orderId, UserId = 1, Status = "Pending" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetOrderByIdQuery>(), default))
                .ReturnsAsync(orderDto);

            // Act
            var result = await _controller.GetOrderById(orderId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedOrder = Assert.IsType<OrderDto>(okResult.Value);
            Assert.Equal(orderId, returnedOrder.Id);
        }

        [Fact]
        public async Task GetOrders_ReturnsListOfOrders()
        {
            // Arrange
            var orders = new List<OrderDto> 
            { 
                new OrderDto { Id = 1, UserId = 1, Status = "Pending" },
                new OrderDto { Id = 2, UserId = 1, Status = "Completed" }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetOrdersQuery>(), default))
                .ReturnsAsync(orders);

            // Act
            var result = await _controller.GetOrders();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedOrders = Assert.IsType<List<OrderDto>>(okResult.Value);
            Assert.Equal(2, returnedOrders.Count);
        }

        [Fact]
        public async Task UpdateOrder_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new UpdateOrderCommand 
            { 
                Id = 1,
                Status = "Completed"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateOrderCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.UpdateOrder(command);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteOrder_ExistingOrder_ReturnsOkResult()
        {
            // Arrange
            var orderId = 1;
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteOrderCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.DeleteOrder(orderId);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}

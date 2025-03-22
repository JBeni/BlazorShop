// <copyright file="CartsControllerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Controllers
{
    /// <summary>
    /// Tests for <see cref="CartsController"/> class.
    /// </summary>
    public class CartsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly CartsController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartsControllerTests"/> class.
        /// </summary>
        public CartsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new CartsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateCart_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new CreateCartCommand 
            { 
                UserId = 1,
                ProductId = 1,
                Quantity = 1
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateCartCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.CreateCart(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task GetCartById_ExistingCart_ReturnsOkResult()
        {
            // Arrange
            var cartId = 1;
            var cartDto = new CartDto { Id = cartId, UserId = 1 };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetCartByIdQuery>(), default))
                .ReturnsAsync(cartDto);

            // Act
            var result = await _controller.GetCartById(cartId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedCart = Assert.IsType<CartDto>(okResult.Value);
            Assert.Equal(cartId, returnedCart.Id);
        }

        [Fact]
        public async Task GetCarts_ReturnsListOfCarts()
        {
            // Arrange
            var carts = new List<CartDto> 
            { 
                new CartDto { Id = 1, UserId = 1 },
                new CartDto { Id = 2, UserId = 1 }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetCartsQuery>(), default))
                .ReturnsAsync(carts);

            // Act
            var result = await _controller.GetCarts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedCarts = Assert.IsType<List<CartDto>>(okResult.Value);
            Assert.Equal(2, returnedCarts.Count);
        }

        [Fact]
        public async Task UpdateCart_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new UpdateCartCommand { Id = 1, Quantity = 2 };
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateCartCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.UpdateCart(command);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteCart_ExistingCart_ReturnsOkResult()
        {
            // Arrange
            var cartId = 1;
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteCartCommand>(), default))
                .ReturnsAsync(Result.Success());

            // Act
            var result = await _controller.DeleteCart(cartId);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}

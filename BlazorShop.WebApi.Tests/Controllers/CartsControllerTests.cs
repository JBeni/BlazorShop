// <copyright file="CartsControllerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Controllers
{
    /// <summary>
    /// Tests for <see cref="WebApi.Controllers.CartsController"/> class.
    /// </summary>
    public class CartsControllerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CartsControllerTests"/> class.
        /// </summary>
        public CartsControllerTests()
        {
            this.CartsController = new CartsController(this.Mediator);
        }

        /// <summary>
        /// Gets a mock instance of the <see cref="IMediator"/> to use.
        /// </summary>
        private IMediator Mediator { get; } = Mock.Of<IMediator>();

        /// <summary>
        /// Gets the <see cref="WebApi.Controllers.CartsController"/> instance to use.
        /// </summary>
        private CartsController CartsController { get; }

        /// <summary>
        /// A test for <see cref="CartsController.CreateCart(CreateCartCommand)"/>.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreateCart()
        {
            var command = Mock.Of<CreateCartCommand>(x =>
                x.UserId == new Random().Next() &&
                x.ClotheId == new Random().Next() &&
                x.Name == "Test Cart" &&
                x.Price == new decimal(new Random().NextDouble()) &&
                x.Amount == new Random().Next());

            var requestResponse = Mock.Of<RequestResponse>(x =>
                x.Successful == true &&
                x.Error == null);

            Mock.Get(this.Mediator)
                .Setup(x => x.Send(It.IsAny<CreateCartCommand>(), default))
                .ReturnsAsync(requestResponse);

            var result = await this.CartsController.CreateCart(command);

            var okResult = Assert.IsAssignableFrom<OkObjectResult>(result);
            var resultRequest = Assert.IsAssignableFrom<RequestResponse>(okResult.Value);

            Assert.Equal(resultRequest.Successful, requestResponse.Successful);
            Assert.Equal(resultRequest.Error, requestResponse.Error);
            Assert.Equal(resultRequest.EntityId, requestResponse.EntityId);
        }

        /// <summary>
        /// A test for <see cref="CartsController.DeleteAllCarts(int)"/>.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteAllCarts()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="CartsController.DeleteCart(int, int)"/>.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteCart()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="CartsController.GetCart(int, int)"/>.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetCart()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="CartsController.GetCarts(int)"/>.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetCarts()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="CartsController.GetCartsCount(int)"/>.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetCartsCount()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="CartsController.UpdateCart(UpdateCartCommand)"/>.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateCart()
        {
            await Task.CompletedTask;
        }
    }
}

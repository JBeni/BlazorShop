// <copyright file="OrdersControllerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Tests.Controllers
{
    /// <summary>
    /// Tests for <see cref="OrdersController"/> class.
    /// </summary>
    public class OrdersControllerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersControllerTests"/> class.
        /// </summary>
        public OrdersControllerTests()
        {
            this.OrdersController = new OrdersController(this.Mediator);
        }

        /// <summary>
        /// Gets the instance of the <see cref="OrdersController"/> to use.
        /// </summary>
        private OrdersController OrdersController { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IMediator"/> to use.
        /// </summary>
        private IMediator Mediator { get; } = Mock.Of<IMediator>();

        /// <summary>
        /// A test for <see cref="OrdersController.CreateOrder(CreateOrderCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreateOrder()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="OrdersController.UpdateOrder(UpdateOrderCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateOrder()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="OrdersController.DeleteOrder(DeleteOrderCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteOrder()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="OrdersController.GetOrder(int, string)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetOrder()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="OrdersController.GetOrders(string)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetOrders()
        {
            await Task.CompletedTask;
        }
    }
}

// <copyright file="OrderServiceTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using OrderService = BlazorShop.WebClient.Services.OrderService;

namespace BlazorShop.UnitTests.WebClient.Services
{
    /// <summary>
    /// Tests for <see cref="BlazorShop.WebClient.Services.OrderService"/> class.
    /// </summary>
    public class OrderServiceTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderServiceTests"/> class.
        /// </summary>
        public OrderServiceTests()
        {
            this.OrderService = new OrderService(
                this.HttpClient,
                this.SnackBar);
        }

        /// <summary>
        /// Gets the instance of the <see cref="OrderService"/> to use.
        /// </summary>
        private OrderService OrderService { get; }

        /// <summary>
        /// Gets the instance of the <see cref="System.Net.Http.HttpClient"/> to use.
        /// </summary>
        private HttpClient HttpClient { get; } = Mock.Of<HttpClient>();

        /// <summary>
        /// Gets the instance of the <see cref="ISnackbar"/> to use.
        /// </summary>
        private ISnackbar SnackBar { get; } = Mock.Of<ISnackbar>();

        /// <summary>
        /// Gets the instance of the <see cref="JsonSerializerOptions"/> to use.
        /// </summary>
        private JsonSerializerOptions Options { get; }

        /// <summary>
        /// A test for <see cref="OrderService.GetOrders(string)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetOrders()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="OrderService.GetOrder(int, string)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetOrder()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="OrderService.AddOrder(OrderResponse)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task AddOrder()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="OrderService.UpdateOrder(OrderResponse)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateOrder()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="OrderService.DeleteOrder(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteOrder()
        {
            await Task.CompletedTask;
        }
    }
}

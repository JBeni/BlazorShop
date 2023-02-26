// <copyright file="CartServiceTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using CartService = BlazorShop.WebClient.Services.CartService;

namespace BlazorShop.UnitTests.WebClient.Services
{
    /// <summary>
    /// Tests for <see cref="BlazorShop.WebClient.Services.CartService"/> class.
    /// </summary>
    public class CartServiceTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CartServiceTests"/> class.
        /// </summary>
        public CartServiceTests()
        {
            this.CartService = new CartService(
                this.HttpClient,
                this.SnackBar);
        }

        /// <summary>
        /// Gets the instance of the <see cref="CartService"/> to use.
        /// </summary>
        private CartService CartService { get; }

        /// <summary>
        /// Gets the instance of the <see cref="HttpClient"/> to use.
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
        /// A test for <see cref="CartService.AddCart(CartResponse)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task AddCart()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="CartService.DeleteCart(int, int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteCart()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="CartService.EmptyCart(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task EmptyCart()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="CartService.GetCart(int, int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetCart()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="CartService.GetCartCounts(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetCartCounts()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="CartService.GetCarts(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetCarts()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="CartService.UpdateCart(CartResponse)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateCart()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="CartService.Checkout(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Checkout()
        {
            await Task.CompletedTask;
        }
    }
}

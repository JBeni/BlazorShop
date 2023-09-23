// <copyright file="SubscriptionServiceTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using SubscriptionService = BlazorShop.WebClient.Services.SubscriptionService;

namespace BlazorShop.UnitTests.WebClient.Services
{
    /// <summary>
    /// Tests for <see cref="BlazorShop.WebClient.Services.SubscriptionService"/> class.
    /// </summary>
    public class SubscriptionServiceTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionServiceTests"/> class.
        /// </summary>
        public SubscriptionServiceTests()
        {
            this.SubscriptionService = new SubscriptionService(
                this.HttpClient,
                this.SnackBar);
        }

        /// <summary>
        /// Gets the instance of the <see cref="SubscriptionService"/> to use.
        /// </summary>
        private SubscriptionService SubscriptionService { get; }

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
        /// A test for <see cref="SubscriptionService.GetSubscriptions()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetSubscriptions()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="SubscriptionService.GetSubscription(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetSubscription()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="SubscriptionService.AddSubscription(SubscriptionResponse)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task AddSubscription()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="SubscriptionService.UpdateSubscription(SubscriptionResponse)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateSubscription()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="SubscriptionService.DeleteSubscription(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteSubscription()
        {
            await Task.CompletedTask;
        }
    }
}

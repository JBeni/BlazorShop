// <copyright file="SubscriberServiceTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using SubscriberService = BlazorShop.WebClient.Services.SubscriberService;

namespace BlazorShop.UnitTests.WebClient.Services
{
    /// <summary>
    /// Tests for <see cref="BlazorShop.WebClient.Services.SubscriberService"/> class.
    /// </summary>
    public class SubscriberServiceTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriberServiceTests"/> class.
        /// </summary>
        public SubscriberServiceTests()
        {
            this.SubscriberService = new SubscriberService(
                this.HttpClient,
                this.SnackBar);
        }

        /// <summary>
        /// Gets the instance of the <see cref="SubscriberService"/> to use.
        /// </summary>
        private SubscriberService SubscriberService { get; }

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
        /// A test for <see cref="SubscriberService.GetSubscribers()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetSubscribers()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="SubscriberService.GetUserAllSubscribers(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetUserAllSubscribers()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="SubscriberService.GetUserSubscriber(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetUserSubscriber()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="SubscriberService.AddSubscriber(SubscriberResponse)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task AddSubscriber()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="SubscriberService.UpdateSubscriber(SubscriberResponse)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateSubscriber()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="SubscriberService.DeleteSubscriber(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteSubscriber()
        {
            await Task.CompletedTask;
        }
    }
}

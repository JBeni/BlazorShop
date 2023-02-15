// <copyright file="SubscriptionsControllerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Controllers
{
    /// <summary>
    /// Tests for <see cref="SubscriptionsController"/> class.
    /// </summary>
    public class SubscriptionsControllerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionsControllerTests"/> class.
        /// </summary>
        public SubscriptionsControllerTests()
        {
            this.SubscriptionsController = new SubscriptionsController(this.Mediator);
        }

        /// <summary>
        /// Gets the instance of the <see cref="SubscriptionsController"/> to use.
        /// </summary>
        private SubscriptionsController SubscriptionsController { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IMediator"/> to use.
        /// </summary>
        private IMediator Mediator { get; } = Mock.Of<IMediator>();

        /// <summary>
        /// A test for <see cref="SubscriptionsController.CreateSubscription(CreateSubscriptionCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreateSubscription()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="SubscriptionsController.UpdateSubscription(UpdateSubscriptionCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateSubscription()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="SubscriptionsController.DeleteSubscription(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteSubscription()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="SubscriptionsController.GetSubscription(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetSubscription()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="SubscriptionsController.GetSubscriptions()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetSubscriptions()
        {
            await Task.CompletedTask;
        }
    }
}

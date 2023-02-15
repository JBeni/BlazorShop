// <copyright file="SubscribersControllerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Controllers
{
    /// <summary>
    /// Tests for <see cref="SubscribersController"/> class.
    /// </summary>
    public class SubscribersControllerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscribersControllerTests"/> class.
        /// </summary>
        public SubscribersControllerTests()
        {
            this.SubscribersController = new SubscribersController(this.Mediator);
        }

        /// <summary>
        /// Gets the instance of the <see cref="SubscribersController"/> to use.
        /// </summary>
        private SubscribersController SubscribersController { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IMediator"/> to use.
        /// </summary>
        private IMediator Mediator { get; } = Mock.Of<IMediator>();

        /// <summary>
        /// A test for <see cref="SubscribersController.CreateSubscriber(CreateSubscriberCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreateSubscriber()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="SubscribersController.UpdateSubscriber(UpdateSubscriberCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateSubscriber()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="SubscribersController.DeleteSubscriber(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteSubscriber()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="SubscribersController.GetSubscriber(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetSubscriber()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="SubscribersController.GetUserSubscribers(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetUserSubscribers()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="SubscribersController.GetSubscribers()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetSubscribers()
        {
            await Task.CompletedTask;
        }
    }
}

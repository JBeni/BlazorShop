// <copyright file="PaymentsControllerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Tests.Controllers
{
    /// <summary>
    /// Tests for <see cref="PaymentsController"/> class.
    /// </summary>
    public class PaymentsControllerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsControllerTests"/> class.
        /// </summary>
        public PaymentsControllerTests()
        {
            this.PaymentsController = new PaymentsController(this.Configuration, this.Mediator);
        }

        /// <summary>
        /// Gets the instance of the <see cref="PaymentsController"/> to use.
        /// </summary>
        private PaymentsController PaymentsController { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IMediator"/> to use.
        /// </summary>
        private IMediator Mediator { get; } = Mock.Of<IMediator>();

        /// <summary>
        /// Gets the instance of the <see cref="IConfiguration"/> to use.
        /// </summary>
        private IConfiguration Configuration { get; } = Mock.Of<IConfiguration>();

        /// <summary>
        /// A test for <see cref="PaymentsController.CreateSubscriptionSession(CreateSubscriberCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreateSubscriptionSession()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="PaymentsController.CancelSubscriptionSession(string)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CancelSubscriptionSession()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="PaymentsController.UpdateSubscriptionSession(UpdateSubscriberCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateSubscriptionSession()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="PaymentsController.CreateCheckout(List{CartResponse})"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreateCheckout()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="PaymentsController.WebHook()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task WebHook()
        {
            await Task.CompletedTask;
        }
    }
}

// <copyright file="SubscriptionsController.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Controllers
{
    /// <summary>
    /// Controller for Subscriptions.
    /// </summary>
    public class SubscriptionsController : ApiBaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionsController"/> class.
        /// </summary>
        /// <param name="mediator">The instance of the <see cref="IMediator"/> to use.</param>
        public SubscriptionsController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Create a subscription.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}")]
        [HttpPost("subscription")]
        public async Task<IActionResult> CreateSubscription([FromBody] CreateSubscriptionCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Update a subscription.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}")]
        [HttpPut("subscription")]
        public async Task<IActionResult> UpdateSubscription([FromBody] UpdateSubscriptionCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Delete a subscription.
        /// </summary>
        /// <param name="id">The id of the subscription.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}")]
        [HttpDelete("subscription/{id}")]
        public async Task<IActionResult> DeleteSubscription(int id)
        {
            var result = await this.Mediator.Send(new DeleteSubscriptionCommand { Id = id });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get a subscription.
        /// </summary>
        /// <param name="id">The id of the subscription.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}, {StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpGet("subscription/{id}")]
        public async Task<IActionResult> GetSubscription(int id)
        {
            var result = await this.Mediator.Send(new GetSubscriptionByIdQuery { Id = id });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get the subscriptions.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}, {StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpGet("subscriptions")]
        public async Task<IActionResult> GetSubscriptions()
        {
            var result = await this.Mediator.Send(new GetSubscriptionsQuery { });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }
    }
}

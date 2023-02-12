// <copyright file="SubscribersController.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Controllers
{
    /// <summary>
    /// Controller for Subscribers.
    /// </summary>
    public class SubscribersController : ApiBaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscribersController"/> class.
        /// </summary>
        /// <param name="mediator">The instance of the <see cref="IMediator"/> to use.</param>
        public SubscribersController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Create a subscriber.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpPost("subscriber")]
        public async Task<IActionResult> CreateSubscriber([FromBody] CreateSubscriberCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Update a subscriber.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpPut("subscriber")]
        public async Task<IActionResult> UpdateSubscriber([FromBody] UpdateSubscriberCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Delete a subscriber.
        /// </summary>
        /// <param name="id">The id of the subscriber.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}")]
        [HttpDelete("subscriber/{id}")]
        public async Task<IActionResult> DeleteSubscriber(int id)
        {
            var result = await this.Mediator.Send(new DeleteSubscriberCommand { Id = id });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get a subscriber.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpGet("subscriber/{userId}")]
        public async Task<IActionResult> GetSubscriber(int userId)
        {
            var result = await this.Mediator.Send(new GetSubscriberByIdQuery { UserId = userId });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get user subscribers.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}, {StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpGet("subscribers/{userId}")]
        public async Task<IActionResult> GetUserSubscribers(int userId)
        {
            var result = await this.Mediator.Send(new GetUserSubscribersQuery { UserId = userId });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get the subscribers.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = "Admin, User, Default")]
        [HttpGet("subscribers")]
        public async Task<IActionResult> GetSubscribers()
        {
            var result = await this.Mediator.Send(new GetSubscribersQuery { });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }
    }
}

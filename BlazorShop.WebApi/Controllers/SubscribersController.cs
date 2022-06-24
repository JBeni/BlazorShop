// <copyright file="SubscribersController.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Controllers
{
    public class SubscribersController : ApiControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpPost("subscriber")]
        public async Task<IActionResult> CreateSubscriber([FromBody] CreateSubscriberCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpPut("subscriber")]
        public async Task<IActionResult> UpdateSubscriber([FromBody] UpdateSubscriberCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}")]
        [HttpDelete("subscriber/{id}")]
        public async Task<IActionResult> DeleteSubscriber(int id)
        {
            var result = await Mediator.Send(new DeleteSubscriberCommand { Id = id });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpGet("subscriber/{userId}")]
        public async Task<IActionResult> GetSubscriber(int userId)
        {
            var result = await Mediator.Send(new GetSubscriberByIdQuery { UserId = userId });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}, {StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpGet("subscribers/{userId}")]
        public async Task<IActionResult> GetUserSubscribers(int userId)
        {
            var result = await Mediator.Send(new GetUserSubscribersQuery { UserId = userId });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin, User, Default")]
        [HttpGet("subscribers")]
        public async Task<IActionResult> GetSubscribers()
        {
            var result = await Mediator.Send(new GetSubscribersQuery { });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }
    }
}

namespace BlazorShop.WebApi.Controllers
{
    public class SubscriptionsController : ApiControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}")]
        [HttpPost("subscription")]
        public async Task<IActionResult> CreateSubscription([FromBody] CreateSubscriptionCommand command)
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
        [Authorize(Roles = $"{StringRoleResources.Admin}")]
        [HttpPut("subscription")]
        public async Task<IActionResult> UpdateSubscription([FromBody] UpdateSubscriptionCommand command)
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
        [HttpDelete("subscription/{id}")]
        public async Task<IActionResult> DeleteSubscription(int id)
        {
            var result = await Mediator.Send(new DeleteSubscriptionCommand { Id = id });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}, {StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpGet("subscription/{id}")]
        public async Task<IActionResult> GetSubscription(int id)
        {
            var result = await Mediator.Send(new GetSubscriptionByIdQuery { Id = id });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}, {StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpGet("subscriptions")]
        public async Task<IActionResult> GetSubscriptions()
        {
            var result = await Mediator.Send(new GetSubscriptionsQuery { });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }
    }
}

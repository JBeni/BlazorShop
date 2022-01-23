namespace BlazorShop.WebApi.Controllers
{
    public class SubscribersController : ApiControllerBase
    {
        [Authorize(Roles = "Admin, User, Default")]
        [HttpPost("subscriber")]
        public async Task<IActionResult> CreateSubscriber([FromBody] CreateSubscriberCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User, Default")]
        [HttpPut("subscriber")]
        public async Task<IActionResult> UpdateSubscriber([FromBody] UpdateSubscriberCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User, Default")]
        [HttpDelete("subscriber/{id}")]
        public async Task<IActionResult> DeleteSubscriber(int id)
        {
            var result = await Mediator.Send(new DeleteSubscriberCommand { Id = id });
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User, Default")]
        [HttpGet("subscriber/{userId}")]
        public async Task<IActionResult> GetSubscriber(int userId)
        {
            var result = await Mediator.Send(new GetSubscriberByIdQuery { UserId = userId });
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User, Default")]
        [HttpGet("subscribers/{userId}")]
        public async Task<IActionResult> GetUserSubscribers(int userId)
        {
            var result = await Mediator.Send(new GetUserSubscribersQuery { UserId = userId });
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User, Default")]
        [HttpGet("subscribers")]
        public async Task<IActionResult> GetSubscribers()
        {
            var result = await Mediator.Send(new GetSubscribersQuery { });
            return Ok(result);
        }
    }
}

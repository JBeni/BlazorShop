namespace BlazorShop.WebApi.Controllers
{
    public class SubscribersController : ApiControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpPost("subscriber")]
        public async Task<IActionResult> CreateSubscriber([FromBody] CreateSubscriberCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("subscriber")]
        public async Task<IActionResult> UpdateSubscriber([FromBody] UpdateSubscriberCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("subscriber/{id}")]
        public async Task<IActionResult> DeleteSubscriber(int id)
        {
            var result = await Mediator.Send(new DeleteSubscriberCommand { Id = id });
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User, Default")]
        [HttpGet("subscriber/{id}")]
        public async Task<IActionResult> GetSubscriber(int id)
        {
            var result = await Mediator.Send(new GetSubscriberByIdQuery { Id = id });
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

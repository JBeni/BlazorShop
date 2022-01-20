namespace BlazorShop.WebApi.Controllers
{
    public class SubscribersUnitWorkController : ApiControllerBase
    {
        private readonly ISubscriberService _subscriberService;

        public SubscribersUnitWorkController(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("subscriber")]
        public IActionResult CreateSubscriber([FromBody] SubscriberResponse Subscriber)
        {
            var result = _subscriberService.AddSubscriber(Subscriber);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("subscriber")]
        public IActionResult UpdateSubscriber([FromBody] SubscriberResponse Subscriber)
        {
            var result = _subscriberService.UpdateSubscriber(Subscriber);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("subscriber/{id}")]
        public IActionResult DeleteSubscriber(int id)
        {
            var result = _subscriberService.DeleteSubscriber(id);
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User, Default")]
        [HttpGet("subscriber/{id}")]
        public IActionResult GetSubscriber(int id)
        {
            var result = _subscriberService.Get(id);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("subscribers")]
        public IActionResult GetSubscribers()
        {
            var result = _subscriberService.GetAll();
            return Ok(result);
        }
    }
}

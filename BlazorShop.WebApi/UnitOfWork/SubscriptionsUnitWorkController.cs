namespace BlazorShop.WebApi.UnitOfWork
{
    public class SubscriptionsUnitWorkController : ApiControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionsUnitWorkController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("subscription")]
        public IActionResult CreateSubscription([FromBody] SubscriptionResponse Subscription)
        {
            var result = _subscriptionService.AddSubscription(Subscription);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("subscription")]
        public IActionResult UpdateSubscription([FromBody] SubscriptionResponse Subscription)
        {
            var result = _subscriptionService.UpdateSubscription(Subscription);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("subscription/{id}")]
        public IActionResult DeleteSubscription(int id)
        {
            var result = _subscriptionService.DeleteSubscription(id);
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User, Default")]
        [HttpGet("subscription/{id}")]
        public IActionResult GetSubscription(int id)
        {
            var result = _subscriptionService.Get(id);
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User, Default")]
        [HttpGet("subscriptions")]
        public IActionResult GetSubscriptions()
        {
            var result = _subscriptionService.GetAll();
            return Ok(result);
        }
    }
}

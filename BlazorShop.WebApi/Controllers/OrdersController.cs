namespace BlazorShop.WebApi.Controllers
{
    public class OrdersController : ApiControllerBase
    {
        [Authorize(Roles = "User, Default")]
        [HttpPost("order")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "User, Default")]
        [HttpPut("order")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("order")]
        public async Task<IActionResult> DeleteOrder(DeleteOrderCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "User, Default")]
        [HttpGet("order/{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var result = await Mediator.Send(new GetOrderByIdQuery { Id = id });
            return Ok(result);
        }

        [Authorize(Roles = "User, Default")]
        [HttpGet("orders")]
        public async Task<IActionResult> GetOrders()
        {
            var result = await Mediator.Send(new GetOrdersQuery { });
            return Ok(result);
        }
    }
}

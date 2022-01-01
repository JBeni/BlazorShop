namespace BlazorShop.WebApi.Controllers
{
    public class OrdersController : ApiBaseController
    {
        [HttpPost("order")]
        public async Task<IActionResult> CreateOrder([FromQuery] CreateOrderCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("order")]
        public async Task<IActionResult> UpdateOrder([FromQuery] UpdateOrderCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("order")]
        public async Task<IActionResult> DeleteOrder([FromQuery] DeleteOrderCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("order")]
        public async Task<IActionResult> GetOrder([FromQuery] GetOrderByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetOrders([FromQuery] GetOrdersQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}

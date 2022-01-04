namespace BlazorShop.WebApi.Controllers
{
    public class OrdersController : ApiControllerBase
    {
        [HttpPost("order")]
        public async Task<IActionResult> CreateOrder([FromQuery] CreateClotheCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("order")]
        public async Task<IActionResult> UpdateOrder([FromQuery] UpdateClotheCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("order")]
        public async Task<IActionResult> DeleteOrder([FromQuery] DeleteClotheCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("order")]
        public async Task<IActionResult> GetOrder([FromQuery] GetClotheByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetOrders([FromQuery] GetClothesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}

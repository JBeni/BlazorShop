namespace BlazorShop.WebApi.Controllers
{
    public class OrdersController : ApiControllerBase
    {
        [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpPost("order")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpPut("order")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        [Authorize(Roles = $"{StringRoleResources.Admin}")]
        [HttpDelete("order")]
        public async Task<IActionResult> DeleteOrder(DeleteOrderCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpGet("order/{id}/{userEmail}")]
        public async Task<IActionResult> GetOrder(int id, string userEmail)
        {
            var result = await Mediator.Send(new GetOrderByIdQuery { Id = id, UserEmail = userEmail });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpGet("orders/{userEmail}")]
        public async Task<IActionResult> GetOrders(string userEmail)
        {
            var result = await Mediator.Send(new GetOrdersQuery { UserEmail = userEmail });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }
    }
}

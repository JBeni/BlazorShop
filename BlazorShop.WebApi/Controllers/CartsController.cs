namespace BlazorShop.WebApi.Controllers
{
    [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
    public class CartsController : ApiControllerBase
    {
        [HttpPost("cart")]
        public async Task<IActionResult> CreateCart([FromBody] CreateCartCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("cart")]
        public async Task<IActionResult> UpdateCart([FromBody] UpdateCartCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("cart/{id}/{userId}")]
        public async Task<IActionResult> DeleteCart(int id, int userId)
        {
            var result = await Mediator.Send(new DeleteCartCommand { Id = id, UserId = userId });
            return Ok(result);
        }

        [HttpDelete("carts/{userId}")]
        public async Task<IActionResult> DeleteAllCarts(int userId)
        {
            var result = await Mediator.Send(new DeleteAllCartsCommand { UserId = userId });
            return Ok(result);
        }

        [HttpGet("cart/{id}")]
        public async Task<IActionResult> GetCart(int id)
        {
            var result = await Mediator.Send(new GetCartByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet("carts/{userId}")]
        public async Task<IActionResult> GetCarts(int userId)
        {
            var result = await Mediator.Send(new GetCartsQuery { UserId = userId });
            return Ok(result);
        }

        [HttpGet("count/{userId}")]
        public async Task<IActionResult> GetCartsCount(int userId)
        {
            var result = await Mediator.Send(new GetCartsCountQuery { UserId = userId });
            return Ok(result);
        }
    }
}

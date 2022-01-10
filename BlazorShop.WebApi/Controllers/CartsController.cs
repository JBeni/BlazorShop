namespace BlazorShop.WebApi.Controllers
{
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

        [HttpDelete("cart/{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var result = await Mediator.Send(new DeleteCartCommand { Id = id });
            return Ok(result);
        }

        [HttpGet("cart/{id}")]
        public async Task<IActionResult> GetCart(int id)
        {
            var result = await Mediator.Send(new GetCartByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet("carts")]
        public async Task<IActionResult> GetCarts()
        {
            var result = await Mediator.Send(new GetCartsQuery { });
            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetCartsCount()
        {
            var result = await Mediator.Send(new GetCartsCountQuery { });
            return Ok(result);
        }
    }
}

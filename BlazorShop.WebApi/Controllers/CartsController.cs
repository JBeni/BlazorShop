namespace BlazorShop.WebApi.Controllers
{
    [Authorize(Roles = $"{StringRoleResources.User}, {StringRoleResources.Default}")]
    public class CartsController : ApiControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("cart")]
        public async Task<IActionResult> CreateCart([FromBody] CreateCartCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("cart")]
        public async Task<IActionResult> UpdateCart([FromBody] UpdateCartCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete("cart/{id}/{userId}")]
        public async Task<IActionResult> DeleteCart(int id, int userId)
        {
            var result = await Mediator.Send(new DeleteCartCommand { Id = id, UserId = userId });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete("carts/{userId}")]
        public async Task<IActionResult> DeleteAllCarts(int userId)
        {
            var result = await Mediator.Send(new DeleteAllCartsCommand { UserId = userId });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("cart/{id}/{userId}")]
        public async Task<IActionResult> GetCart(int id, int userId)
        {
            var result = await Mediator.Send(new GetCartByIdQuery { Id = id, UserId = userId });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("carts/{userId}")]
        public async Task<IActionResult> GetCarts(int userId)
        {
            var result = await Mediator.Send(new GetCartsQuery { UserId = userId });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("count/{userId}")]
        public async Task<IActionResult> GetCartsCount(int userId)
        {
            var result = await Mediator.Send(new GetCartsCountQuery { UserId = userId });
            return Ok(result);
        }
    }
}

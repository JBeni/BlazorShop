namespace BlazorShop.WebApi.Controllers
{
    public class ProductsController : ApiControllerBase
    {
        [HttpPost("product")]
        public async Task<IActionResult> CreateProduct([FromQuery] CreateProductCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("product")]
        public async Task<IActionResult> UpdateProduct([FromQuery] UpdateProductCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("product")]
        public async Task<IActionResult> DeleteProduct([FromQuery] DeleteProductCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("product/:id")]
        public async Task<IActionResult> GetProduct([FromQuery] GetProductByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts([FromQuery] GetProductsQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}

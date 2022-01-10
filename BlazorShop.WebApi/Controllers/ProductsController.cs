namespace BlazorShop.WebApi.Controllers
{
    public class ProductsController : ApiControllerBase
    {
        [HttpPost("product")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("product")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("product/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await Mediator.Send(new DeleteProductCommand { Id = id });
            return Ok(result);
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await Mediator.Send(new GetProductByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await Mediator.Send(new GetProductsQuery { });
            return Ok(result);
        }
    }
}

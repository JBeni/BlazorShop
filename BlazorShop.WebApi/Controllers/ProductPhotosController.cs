namespace BlazorShop.WebApi.Controllers
{
    public class ProductPhotosController : ApiControllerBase
    {
        [HttpPost("productPhoto")]
        public async Task<IActionResult> CreateProductPhoto([FromQuery] CreateProductPhotoCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("productPhoto")]
        public async Task<IActionResult> UpdateProductPhoto([FromQuery] UpdateProductPhotoCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("productPhoto")]
        public async Task<IActionResult> DeleteProductPhoto([FromQuery] DeleteProductPhotoCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("productPhoto")]
        public async Task<IActionResult> GetProductPhoto([FromQuery] GetProductPhotoByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}

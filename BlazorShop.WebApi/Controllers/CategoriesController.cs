namespace BlazorShop.WebApi.Controllers
{
    public class CategoriesController : ApiControllerBase
    {
        [HttpPost("category")]
        public async Task<IActionResult> CreateCategory([FromQuery] CreateCategoryCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("category")]
        public async Task<IActionResult> UpdateCategory([FromQuery] UpdateCategoryCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("category")]
        public async Task<IActionResult> DeleteCategory([FromQuery] DeleteCategoryCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("category")]
        public async Task<IActionResult> GetCategory([FromQuery] GetCategoryByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories([FromQuery] GetCategoriesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}

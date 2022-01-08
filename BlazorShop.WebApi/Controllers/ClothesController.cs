namespace BlazorShop.WebApi.Controllers
{
    public class ClothesController : ApiControllerBase
    {
        [HttpPost("clothe")]
        public async Task<IActionResult> CreateClothe([FromBody] CreateClotheCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("clothe")]
        public async Task<IActionResult> UpdateClothe([FromBody] UpdateClotheCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("clothe/{id}")]
        public async Task<IActionResult> DeleteClothe(int id)
        {
            var result = await Mediator.Send(new DeleteClotheCommand { Id = id });
            return Ok(result);
        }

        [HttpGet("clothe/{id}")]
        public async Task<IActionResult> GetClothe(int id)
        {
            var result = await Mediator.Send(new GetClotheByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet("clothes")]
        public async Task<IActionResult> GetClothes()
        {
            var result = await Mediator.Send(new GetClothesQuery { });
            return Ok(result);
        }
    }
}

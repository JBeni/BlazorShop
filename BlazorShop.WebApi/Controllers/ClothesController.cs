namespace BlazorShop.WebApi.Controllers
{
    public class ClothesController : ApiControllerBase
    {
        [HttpPost("clothe")]
        public async Task<IActionResult> CreateClothe([FromQuery] CreateClotheCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("clothe")]
        public async Task<IActionResult> UpdateClothe([FromQuery] UpdateClotheCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("clothe")]
        public async Task<IActionResult> DeleteClothe([FromQuery] DeleteClotheCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("clothe")]
        public async Task<IActionResult> GetClothe([FromQuery] GetClotheByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("clothes")]
        public async Task<IActionResult> GetClothes([FromQuery] GetClothesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}

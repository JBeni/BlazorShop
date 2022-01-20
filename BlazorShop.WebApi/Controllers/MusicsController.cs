namespace BlazorShop.WebApi.Controllers
{
    public class MusicsController : ApiControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpPost("music")]
        public async Task<IActionResult> CreateMusic([FromBody] CreateMusicCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("music")]
        public async Task<IActionResult> UpdateMusic([FromBody] UpdateMusicCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("music/{id}")]
        public async Task<IActionResult> DeleteMusic(int id)
        {
            var result = await Mediator.Send(new DeleteMusicCommand { Id = id });
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User, Default")]
        [HttpGet("music/{id}")]
        public async Task<IActionResult> GetMusic(int id)
        {
            var result = await Mediator.Send(new GetMusicByIdQuery { Id = id });
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User, Default")]
        [HttpGet("musics")]
        public async Task<IActionResult> GetMusics()
        {
            var result = await Mediator.Send(new GetMusicsQuery { });
            return Ok(result);
        }
    }
}

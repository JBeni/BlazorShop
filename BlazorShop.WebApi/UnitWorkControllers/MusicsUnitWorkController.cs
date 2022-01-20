namespace BlazorShop.WebApi.Controllers
{
    public class MusicsUnitWorkController : ApiControllerBase
    {
        private readonly IMusicService _musicService;

        public MusicsUnitWorkController(IMusicService musicService)
        {
            _musicService = musicService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("music")]
        public IActionResult CreateMusic([FromBody] MusicResponse music)
        {
            var result = _musicService.AddMusic(music);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("music")]
        public IActionResult UpdateMusic([FromBody] MusicResponse music)
        {
            var result = _musicService.UpdateMusic(music);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("music/{id}")]
        public IActionResult DeleteMusic(int id)
        {
            var result = _musicService.DeleteMusic(id);
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User, Default")]
        [HttpGet("music/{id}")]
        public IActionResult GetMusic(int id)
        {
            var result = _musicService.Get(id);
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User, Default")]
        [HttpGet("musics")]
        public IActionResult GetMusics()
        {
            var result = _musicService.GetAll();
            return Ok(result);
        }
    }
}

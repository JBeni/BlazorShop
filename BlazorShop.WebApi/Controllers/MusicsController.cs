// <copyright file="MusicsController.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Controllers
{
    public class MusicsController : ApiControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}")]
        [HttpPost("music")]
        public async Task<IActionResult> CreateMusic([FromBody] CreateMusicCommand command)
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
        [Authorize(Roles = $"{StringRoleResources.Admin}")]
        [HttpPut("music")]
        public async Task<IActionResult> UpdateMusic([FromBody] UpdateMusicCommand command)
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
        /// <returns></returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}")]
        [HttpDelete("music/{id}")]
        public async Task<IActionResult> DeleteMusic(int id)
        {
            var result = await Mediator.Send(new DeleteMusicCommand { Id = id });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}, {StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpGet("music/{id}")]
        public async Task<IActionResult> GetMusic(int id)
        {
            var result = await Mediator.Send(new GetMusicByIdQuery { Id = id });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}, {StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpGet("musics")]
        public async Task<IActionResult> GetMusics()
        {
            var result = await Mediator.Send(new GetMusicsQuery { });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }
    }
}

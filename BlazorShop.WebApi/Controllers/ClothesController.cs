namespace BlazorShop.WebApi.Controllers
{
    public class ClothesController : ApiControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}")]
        [HttpPost("clothe")]
        public async Task<IActionResult> CreateClothe([FromBody] CreateClotheCommand command)
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
        [HttpPut("clothe")]
        public async Task<IActionResult> UpdateClothe([FromBody] UpdateClotheCommand command)
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
        [HttpDelete("clothe/{id}")]
        public async Task<IActionResult> DeleteClothe(int id)
        {
            var result = await Mediator.Send(new DeleteClotheCommand { Id = id });
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
        [HttpGet("clothe/{id}")]
        public async Task<IActionResult> GetClothe(int id)
        {
            var result = await Mediator.Send(new GetClotheByIdQuery { Id = id });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}, {StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpGet("clothes")]
        public async Task<IActionResult> GetClothes()
        {
            var result = await Mediator.Send(new GetClothesQuery { });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }
    }
}

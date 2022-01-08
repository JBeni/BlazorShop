namespace BlazorShop.WebApi.Controllers
{
    public class AppRolesController : ApiControllerBase
    {
        [HttpPost("role")]
        public async Task<IActionResult> CreateRole([FromQuery] CreateRoleCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("role")]
        public async Task<IActionResult> UpdateRole([FromQuery] UpdateRoleCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("role")]
        public async Task<IActionResult> DeleteRole([FromQuery] DeleteRoleCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("role")]
        public async Task<IActionResult> GetRoleById([FromQuery] GetRoleByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles([FromQuery] GetRolesQuery query)
        {
            var result = await Mediator.Send(query);
            result = result.Where(x => x.Name != "Admin").ToList();
            return Ok(result);
        }
    }
}

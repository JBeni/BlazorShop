namespace BlazorShop.WebApi.Controllers
{
    [Authorize(Roles = $"{StringRoleResources.Admin}")]
    public class RolesController : ApiControllerBase
    {
        [HttpPost("role")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand command)
        {
            command.Name = null;
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("role")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("role/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await Mediator.Send(new DeleteRoleCommand { Id = id });
            return Ok(result);
        }

        [HttpGet("role/{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var result = await Mediator.Send(new GetRoleByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles()
        {
            var result = await Mediator.Send(new GetRolesQuery { });
            result = result.Where(x => x.Name != StringRoleResources.Admin).ToList();
            return Ok(result);
        }
    }
}

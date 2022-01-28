namespace BlazorShop.WebApi.Controllers
{
    [Authorize(Roles = $"{StringRoleResources.Admin}")]
    public class RolesController : ApiControllerBase
    {
        [HttpPost("role")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPut("role")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpDelete("role/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await Mediator.Send(new DeleteRoleCommand { Id = id });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpGet("role/{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var result = await Mediator.Send(new GetRoleByIdQuery { Id = id });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles()
        {
            var result = await Mediator.Send(new GetRolesQuery { });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpGet("rolesAdmin")]
        public async Task<IActionResult> GetRolesForAdmin()
        {
            var result = await Mediator.Send(new GetRolesForAdminQuery { });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }
    }
}

namespace BlazorShop.WebApi.Controllers
{
    public class AppUsersController : ApiControllerBase
    {
        [HttpPost("user")]
        public async Task<IActionResult> CreateUser([FromQuery] CreateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("user")]
        public async Task<IActionResult> UpdateUser([FromQuery] UpdateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("user")]
        public async Task<IActionResult> DeleteUser([FromQuery] DeleteUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("user")]
        public async Task<IActionResult> AssignUserToRole([FromQuery] AssignUserToRoleCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("user")]
        public async Task<IActionResult> RemoveUserFromRole([FromQuery] RemoveUserFromRoleCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserById([FromQuery] GetUserByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}

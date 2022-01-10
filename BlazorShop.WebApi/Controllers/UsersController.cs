namespace BlazorShop.WebApi.Controllers
{
    public class UsersController : ApiControllerBase
    {
        [HttpPost("user")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("user")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("userEmail")]
        public async Task<IActionResult> UpdateUserEmail([FromBody] UpdateUserEmailCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("user/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await Mediator.Send(new DeleteUserCommand { Id = id });
            return Ok(result);
        }

        [HttpPost("user")]
        public async Task<IActionResult> AssignUserToRole([FromQuery] AssignUserToRoleCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await Mediator.Send(new GetUserByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await Mediator.Send(new GetUsersQuery { });
            return Ok(result);
        }
    }
}

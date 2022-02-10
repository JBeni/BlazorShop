namespace BlazorShop.WebApi.Controllers
{
    [Authorize(Roles = $"{StringRoleResources.Admin}, {StringRoleResources.User}, {StringRoleResources.Default}")]
    public class TodoListsController : ApiControllerBase
    {
        [HttpPost("list")]
        public async Task<IActionResult> CreateTodoList([FromBody] CreateTodoListCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPut("list")]
        public async Task<IActionResult> UpdateTodoList([FromBody] UpdateTodoListCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpDelete("list/{id}")]
        public async Task<IActionResult> DeleteTodoList(int id)
        {
            var result = await Mediator.Send(new DeleteTodoListCommand { Id = id });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpGet("list/{id}")]
        public async Task<IActionResult> GetTodoListById(int id)
        {
            var result = await Mediator.Send(new GetTodoListByIdQuery { Id = id });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpGet("lists")]
        public async Task<IActionResult> GetTodoLists()
        {
            var result = await Mediator.Send(new GetTodoListsQuery { });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }
    }
}

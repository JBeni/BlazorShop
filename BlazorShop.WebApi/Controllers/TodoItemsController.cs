using BlazorShop.Application.Commands.TodoItemCommand;

namespace BlazorShop.WebApi.Controllers
{
    [Authorize(Roles = $"{StringRoleResources.Admin}, {StringRoleResources.User}, {StringRoleResources.Default}")]
    public class TodoItemsController : ApiControllerBase
    {
        [HttpPost("item")]
        public async Task<IActionResult> CreateTodoItem([FromBody] CreateTodoItemCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPut("item")]
        public async Task<IActionResult> UpdateTodoItem([FromBody] UpdateTodoItemCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpDelete("item/{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var result = await Mediator.Send(new DeleteTodoItemCommand { Id = id });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpGet("item/{id}")]
        public async Task<IActionResult> GetTodoItemById(int id)
        {
            var result = await Mediator.Send(new GetTodoItemByIdQuery { Id = id });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }
    }
}

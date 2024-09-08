// <copyright file="TodoListsController.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Controllers
{
    /// <summary>
    /// Controller for TodoLists.
    /// </summary>
    [Authorize(Roles = $"{StringRoleResources.Admin}, {StringRoleResources.User}, {StringRoleResources.Default}")]
    public class TodoListsController : ApiBaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TodoListsController"/> class.
        /// </summary>
        /// <param name="mediator">The instance of the <see cref="IMediator"/> to use.</param>
        public TodoListsController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Create the todo list.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpPost(ApiEndpoints.TodoLists.Create)]
        public async Task<IActionResult> CreateTodoList([FromBody] CreateTodoListCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Update the todo list.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpPut(ApiEndpoints.TodoLists.Update)]
        public async Task<IActionResult> UpdateTodoList(int id, [FromBody] UpdateTodoListCommand command)
        {
            command.Id = id;
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Delete the todo list.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpDelete(ApiEndpoints.TodoLists.Delete)]
        public async Task<IActionResult> DeleteTodoList(int id)
        {
            var result = await this.Mediator.Send(new DeleteTodoListCommand { Id = id });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get the todo list.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpGet(ApiEndpoints.TodoLists.Get)]
        public async Task<IActionResult> GetTodoListById(int id)
        {
            var result = await this.Mediator.Send(new GetTodoListByIdQuery { Id = id });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get the todo lists.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpGet(ApiEndpoints.TodoLists.GetAll)]
        public async Task<IActionResult> GetTodoLists()
        {
            var result = await this.Mediator.Send(new GetTodoListsQuery { });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }
    }
}

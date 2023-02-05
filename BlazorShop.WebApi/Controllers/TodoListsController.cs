// <copyright file="TodoListsController.cs" company="Beniamin Jitca" author="Beniamin Jitca">
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
        /// Create the todo list.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPost("list")]
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
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPut("list")]
        public async Task<IActionResult> UpdateTodoList([FromBody] UpdateTodoListCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Delete the todo list.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpDelete("list/{id}")]
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
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet("list/{id}")]
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
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet("lists")]
        public async Task<IActionResult> GetTodoLists()
        {
            var result = await this.Mediator.Send(new GetTodoListsQuery { });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }
    }
}

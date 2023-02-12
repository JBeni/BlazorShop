// <copyright file="TodoItemsController.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Controllers
{
    /// <summary>
    /// Controller for TodoItems.
    /// </summary>
    [Authorize(Roles = $"{StringRoleResources.Admin}, {StringRoleResources.User}, {StringRoleResources.Default}")]
    public class TodoItemsController : ApiBaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TodoItemsController"/> class.
        /// </summary>
        /// <param name="mediator">The instance of the <see cref="IMediator"/> to use.</param>
        public TodoItemsController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Create the todo item.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPost("item")]
        public async Task<IActionResult> CreateTodoItem([FromBody] CreateTodoItemCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Update the todo item.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPut("item")]
        public async Task<IActionResult> UpdateTodoItem([FromBody] UpdateTodoItemCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Delete the todo item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpDelete("item/{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var result = await this.Mediator.Send(new DeleteTodoItemCommand { Id = id });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get the todo item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet("item/{id}")]
        public async Task<IActionResult> GetTodoItemById(int id)
        {
            var result = await this.Mediator.Send(new GetTodoItemByIdQuery { Id = id });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }
    }
}

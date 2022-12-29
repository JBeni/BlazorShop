// <copyright file="TodoItemsController.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Commands.TodoItemCommand;

namespace BlazorShop.WebApi.Controllers
{
    /// <summary>
    /// Controller for TodoItems.
    /// </summary>
    [Authorize(Roles = $"{StringRoleResources.Admin}, {StringRoleResources.User}, {StringRoleResources.Default}")]
    public class TodoItemsController : ApiControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("item")]
        public async Task<IActionResult> CreateTodoItem([FromBody] CreateTodoItemCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("item")]
        public async Task<IActionResult> UpdateTodoItem([FromBody] UpdateTodoItemCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("item/{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var result = await Mediator.Send(new DeleteTodoItemCommand { Id = id });
            return result.Successful == true
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

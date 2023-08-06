// <copyright file="ITodoItemService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interfaces
{
    /// <summary>
    /// The service to interact with the todoitem.
    /// </summary>
    public interface ITodoItemService
    {
        /// <summary>
        /// Gets the todo item by id.
        /// </summary>
        /// <param name="id">The required todo item id.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<TodoItemResponse> GetTodoItemAsync(int id);

        /// <summary>
        /// Update a todo item.
        /// </summary>
        /// <param name="todoItem">The required todo item.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> PutTodoItemAsync(TodoItemResponse todoItem);

        /// <summary>
        /// Delete the todo item by id.
        /// </summary>
        /// <param name="id">The required todo item id.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> DeleteTodoItemAsync(int id);

        /// <summary>
        /// Creates a todo item.
        /// </summary>
        /// <param name="todoItem">The required todo item.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<TodoItemResponse> PostTodoItemAsync(TodoItemResponse todoItem);
    }
}

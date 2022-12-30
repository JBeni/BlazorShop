// <copyright file="ITodoListService.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interfaces
{
    /// <summary>
    /// The service to interact with the todolist.
    /// </summary>
    public interface ITodoListService
    {
        /// <summary>
        /// Get the todo lists.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<TodoListResponse>> GetTodoListsAsync();

        /// <summary>
        /// Get the todo list.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<TodoListResponse> GetTodoListAsync(int id);

        /// <summary>
        /// Save a list.
        /// </summary>
        /// <param name="todoList">The todo list.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<TodoListResponse> PostTodoListAsync(TodoListResponse todoList);

        /// <summary>
        /// Update a list.
        /// </summary>
        /// <param name="todoList">The todo list.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<RequestResponse> PutTodoListAsync(TodoListResponse todoList);

        /// <summary>
        /// Delete a list.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<RequestResponse> DeleteTodoListAsync(int id);
    }
}

// <copyright file="ITodoListService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interfaces
{
    public interface ITodoListService
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<List<TodoListResponse>> GetTodoListsAsync();

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<TodoListResponse> GetTodoListAsync(int id);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<TodoListResponse> PostTodoListAsync(TodoListResponse todoList);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<RequestResponse> PutTodoListAsync(TodoListResponse todoList);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<RequestResponse> DeleteTodoListAsync(int id);
    }
}

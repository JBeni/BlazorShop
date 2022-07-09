// <copyright file="GetTodoItemByIdQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.TodoItemQuery
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetTodoItemByIdQuery : IRequest<Result<TodoItemResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}

// <copyright file="GetTodoItemByIdQuery.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.TodoItemQuery
{
    /// <summary>
    /// A model to get the item.
    /// </summary>
    public class GetTodoItemByIdQuery : IRequest<Result<TodoItemResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}

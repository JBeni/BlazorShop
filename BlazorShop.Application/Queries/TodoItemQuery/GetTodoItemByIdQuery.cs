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
        /// Gets or sets the id of the todo item.
        /// </summary>
        public int Id { get; set; }
    }
}

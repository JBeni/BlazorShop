// <copyright file="GetTodoItemByIdQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.TodoItemQuery
{
    public class GetTodoItemByIdQuery : IRequest<Result<TodoItemResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}

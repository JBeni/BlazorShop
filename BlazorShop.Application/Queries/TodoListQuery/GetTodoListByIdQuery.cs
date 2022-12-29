// <copyright file="GetTodoListByIdQuery.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.TodoListQuery
{
    /// <summary>
    /// A model to get the list.
    /// </summary>
    public class GetTodoListByIdQuery : IRequest<Result<TodoListResponse>>
    {
        /// <summary>
        /// The id of the list.
        /// </summary>
        public int Id { get; set; }
    }
}

// <copyright file="GetTodoListsQuery.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.TodoListQuery
{
    /// <summary>
    /// A model to get the lists.
    /// </summary>
    public class GetTodoListsQuery : IRequest<Result<TodoListResponse>>
    {
    }
}

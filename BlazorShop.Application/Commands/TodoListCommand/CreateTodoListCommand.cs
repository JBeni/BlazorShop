// <copyright file="CreateTodoListCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.TodoListCommand
{
    public class CreateTodoListCommand : IRequest<Result<TodoListResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Title { get; set; }
    }
}

﻿// <copyright file="CreateTodoListCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.TodoListCommand
{
    /// <summary>
    /// A model to create a list.
    /// </summary>
    public class CreateTodoListCommand : IRequest<Result<TodoListResponse>>
    {
        /// <summary>
        /// Gets or sets The id of the list.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets The title of the list.
        /// </summary>
        public string? Title { get; set; }
    }
}

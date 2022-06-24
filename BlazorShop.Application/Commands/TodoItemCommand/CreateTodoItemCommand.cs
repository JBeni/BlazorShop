// <copyright file="CreateTodoItemCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.TodoItemCommand
{
    public class CreateTodoItemCommand : IRequest<Result<TodoItemResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public int ListId { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Note { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public TodoItemPriority Priority { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public TodoItemState State { get; set; }
    }
}

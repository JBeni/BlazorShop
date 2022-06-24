// <copyright file="UpdateTodoItemCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.TodoItemCommand
{
    public class UpdateTodoItemCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }

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

        /// <summary>
        /// .
        /// </summary>
        public bool Done { get; set; }
    }
}

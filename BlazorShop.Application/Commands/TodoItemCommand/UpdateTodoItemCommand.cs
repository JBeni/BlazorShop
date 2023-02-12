// <copyright file="UpdateTodoItemCommand.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.TodoItemCommand
{
    /// <summary>
    /// A model to update an item.
    /// </summary>
    public class UpdateTodoItemCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The id of the item.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets The title of the item.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets The note of the item.
        /// </summary>
        public string? Note { get; set; }

        /// <summary>
        /// Gets or sets The priority of the item.
        /// </summary>
        public TodoItemPriority Priority { get; set; }

        /// <summary>
        /// Gets or sets The state of the item.
        /// </summary>
        public TodoItemState State { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the status is completed.
        /// </summary>
        public bool Done { get; set; }
    }
}

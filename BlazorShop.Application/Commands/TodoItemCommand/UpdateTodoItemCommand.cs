// <copyright file="UpdateTodoItemCommand.cs" author="Beniamin Jitca">
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
        /// The id of the item.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the item.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// The note of the item.
        /// </summary>
        public string? Note { get; set; }

        /// <summary>
        /// The priority of the item.
        /// </summary>
        public TodoItemPriority Priority { get; set; }

        /// <summary>
        /// The state of the item.
        /// </summary>
        public TodoItemState State { get; set; }

        /// <summary>
        /// The status of the item.
        /// </summary>
        public bool Done { get; set; }
    }
}

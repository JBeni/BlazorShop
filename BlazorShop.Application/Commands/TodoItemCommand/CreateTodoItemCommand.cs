// <copyright file="CreateTodoItemCommand.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.TodoItemCommand
{
    /// <summary>
    /// A model to create an item.
    /// </summary>
    public class CreateTodoItemCommand : IRequest<Result<TodoItemResponse>>
    {
        /// <summary>
        /// The id of the item.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The id of the list.
        /// </summary>
        public int ListId { get; set; }

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
    }
}

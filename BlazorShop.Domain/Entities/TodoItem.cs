// <copyright file="TodoItem.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Entities
{
    /// <summary>
    /// A template for the entity todo item.
    /// </summary>
    public class TodoItem : EntityBase
    {
        /// <summary>
        /// Gets or sets the title of the todo item.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the note of the todo item.
        /// </summary>
        public string? Note { get; set; }

        /// <summary>
        /// Gets or sets the priority of the todo item.
        /// </summary>
        public TodoItemPriority Priority { get; set; }

        /// <summary>
        /// Gets or sets the state of the todo item.
        /// </summary>
        public TodoItemState State { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the status of the todo item.
        /// </summary>
        public bool Done { get; set; }

        /// <summary>
        /// Gets or sets the list of the todo item.
        /// </summary>
        public TodoList List { get; set; }
    }
}

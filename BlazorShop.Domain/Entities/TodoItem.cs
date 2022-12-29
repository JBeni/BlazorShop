// <copyright file="TodoItem.cs" author="Beniamin Jitca">
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

        /// <summary>
        /// .
        /// </summary>
        public TodoList List { get; set; }
    }
}

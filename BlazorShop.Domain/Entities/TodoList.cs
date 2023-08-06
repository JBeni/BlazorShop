// <copyright file="TodoList.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Entities
{
    /// <summary>
    /// A template for the entity todo list.
    /// </summary>
    public class TodoList : EntityBase
    {
        /// <summary>
        /// Gets or sets the title of the todo list.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the items of the todo list.
        /// </summary>
        public virtual ICollection<TodoItem> Items { get; set; }
    }
}

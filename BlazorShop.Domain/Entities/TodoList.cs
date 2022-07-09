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
        /// .
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public virtual ICollection<TodoItem> Items { get; set; }
    }
}

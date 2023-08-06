// <copyright file="DeleteTodoItemCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.TodoItemCommand
{
    /// <summary>
    /// A model to delete an item.
    /// </summary>
    public class DeleteTodoItemCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The id of the item.
        /// </summary>
        public int Id { get; set; }
    }
}

// <copyright file="DeleteTodoItemCommand.cs" author="Beniamin Jitca">
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
        /// The id of the item.
        /// </summary>
        public int Id { get; set; }
    }
}

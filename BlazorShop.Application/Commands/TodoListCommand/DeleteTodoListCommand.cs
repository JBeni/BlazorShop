// <copyright file="DeleteTodoListCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.TodoListCommand
{
    /// <summary>
    /// A model to delete a list.
    /// </summary>
    public class DeleteTodoListCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The id of the list.
        /// </summary>
        public int Id { get; set; }
    }
}

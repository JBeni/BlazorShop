// <copyright file="DeleteTodoListCommand.cs" author="Beniamin Jitca">
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
        /// The id of the list.
        /// </summary>
        public int Id { get; set; }
    }
}

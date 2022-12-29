// <copyright file="UpdateTodoListCommand.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.TodoListCommand
{
    /// <summary>
    /// A model to update a list.
    /// </summary>
    public class UpdateTodoListCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// The id of the list.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the list.
        /// </summary>
        public string? Title { get; set; }
    }
}

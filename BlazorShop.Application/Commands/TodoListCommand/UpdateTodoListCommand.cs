// <copyright file="UpdateTodoListCommand.cs" company="Beniamin Jitca" author="Beniamin Jitca">
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
        /// Gets or sets The id of the list.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets The title of the list.
        /// </summary>
        public string? Title { get; set; }
    }
}

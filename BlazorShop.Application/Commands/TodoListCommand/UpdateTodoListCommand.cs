// <copyright file="UpdateTodoListCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.TodoListCommand
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class UpdateTodoListCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Title { get; set; }
    }
}

// <copyright file="CreateUserCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.UserCommand
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class CreateUserCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Role { get; set; }
    }
}

// <copyright file="CreateUserCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.UserCommand
{
    /// <summary>
    /// A model to create an user.
    /// </summary>
    public class CreateUserCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The email of the user.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets The first name of the user.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets The last name of the user.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets The role of the user.
        /// </summary>
        public string? Role { get; set; }
    }
}

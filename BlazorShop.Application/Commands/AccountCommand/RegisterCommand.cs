// <copyright file="RegisterCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.AccountCommand
{
    /// <summary>
    /// A model to register the user.
    /// </summary>
    public class RegisterCommand : IRequest<JwtTokenResponse>
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
        public string? RoleName { get; set; }

        /// <summary>
        /// Gets or sets The password to be used.
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets The confirmed password to be used.
        /// </summary>
        public string? ConfirmPassword { get; set; }
    }
}

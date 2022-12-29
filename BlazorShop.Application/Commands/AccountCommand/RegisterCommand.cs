// <copyright file="RegisterCommand.cs" author="Beniamin Jitca">
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
        /// The email of the user.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// The first name of the user.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// The last name of the user.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// The role of the user.
        /// </summary>
        public string? RoleName { get; set; }

        /// <summary>
        /// The password to be used.
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// The confirmed password to be used.
        /// </summary>
        public string? ConfirmPassword { get; set; }
    }
}

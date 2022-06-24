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
        public string? RoleName { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? ConfirmPassword { get; set; }
    }
}

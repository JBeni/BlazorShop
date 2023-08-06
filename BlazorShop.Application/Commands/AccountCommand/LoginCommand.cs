// <copyright file="LoginCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.AccountCommand
{
    /// <summary>
    /// A model to login the user.
    /// </summary>
    public class LoginCommand : IRequest<JwtTokenResponse>
    {
        /// <summary>
        /// Gets or sets The email of the user.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets The password to logged in.
        /// </summary>
        public string? Password { get; set; }
    }
}

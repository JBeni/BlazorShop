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
        /// .
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Password { get; set; }
    }
}

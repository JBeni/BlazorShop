// <copyright file="LoginCommand.cs" author="Beniamin Jitca">
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
        /// The email of the user.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// The password to logged in.
        /// </summary>
        public string? Password { get; set; }
    }
}

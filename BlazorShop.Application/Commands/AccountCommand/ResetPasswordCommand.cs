// <copyright file="ResetPasswordCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.AccountCommand
{
    /// <summary>
    /// A model to reset the password.
    /// </summary>
    public class ResetPasswordCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? NewPassword { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? NewConfirmPassword { get; set; }
    }
}

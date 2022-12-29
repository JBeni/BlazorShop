// <copyright file="ResetPasswordCommand.cs" author="Beniamin Jitca">
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
        /// The email of the user.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// The new password to be used.
        /// </summary>
        public string? NewPassword { get; set; }

        /// <summary>
        /// The new confirmed password to be used.
        /// </summary>
        public string? NewConfirmPassword { get; set; }
    }
}

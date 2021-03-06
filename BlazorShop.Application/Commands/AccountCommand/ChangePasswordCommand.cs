// <copyright file="ChangePasswordCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.AccountCommand
{
    /// <summary>
    /// A model to change the passwword.
    /// </summary>
    public class ChangePasswordCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// The
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? OldPassword { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? NewPassword { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? ConfirmNewPassword { get; set; }
    }
}

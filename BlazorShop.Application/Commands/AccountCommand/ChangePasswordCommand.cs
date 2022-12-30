// <copyright file="ChangePasswordCommand.cs" company="Beniamin Jitca" author="Beniamin Jitca">
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
        /// Gets or sets The id of the user.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets The old password used.
        /// </summary>
        public string? OldPassword { get; set; }

        /// <summary>
        /// Gets or sets The new password to be used.
        /// </summary>
        public string? NewPassword { get; set; }

        /// <summary>
        /// Gets or sets The confirmed password to be used.
        /// </summary>
        public string? ConfirmNewPassword { get; set; }
    }
}

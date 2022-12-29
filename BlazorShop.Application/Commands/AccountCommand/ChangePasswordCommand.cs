// <copyright file="ChangePasswordCommand.cs" author="Beniamin Jitca">
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
        /// The id of the user.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The old password used.
        /// </summary>
        public string? OldPassword { get; set; }

        /// <summary>
        /// The new password to be used.
        /// </summary>
        public string? NewPassword { get; set; }

        /// <summary>
        /// The confirmed password to be used.
        /// </summary>
        public string? ConfirmNewPassword { get; set; }
    }
}

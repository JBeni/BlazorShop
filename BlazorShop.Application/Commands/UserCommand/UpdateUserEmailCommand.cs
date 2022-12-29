// <copyright file="UpdateUserEmailCommand.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.UserCommand
{
    /// <summary>
    /// A model to update the email of the user.
    /// </summary>
    public class UpdateUserEmailCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// The id of the user.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The email of the user.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// The new email of the user.
        /// </summary>
        public string? NewEmail { get; set; }
    }
}

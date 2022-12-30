// <copyright file="UpdateUserEmailCommand.cs" company="Beniamin Jitca" author="Beniamin Jitca">
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
        /// Gets or sets The id of the user.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets The email of the user.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets The new email of the user.
        /// </summary>
        public string? NewEmail { get; set; }
    }
}

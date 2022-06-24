// <copyright file="UpdateUserEmailCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.UserCommand
{
    public class UpdateUserEmailCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? NewEmail { get; set; }
    }
}

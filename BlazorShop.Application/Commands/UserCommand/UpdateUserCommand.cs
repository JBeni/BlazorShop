// <copyright file="UpdateUserCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.UserCommand
{
    public class UpdateUserCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Role { get; set; }
    }
}

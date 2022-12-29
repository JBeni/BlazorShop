// <copyright file="UpdateUserCommand.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.UserCommand
{
    /// <summary>
    /// A model to update an user.
    /// </summary>
    public class UpdateUserCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// The id of the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The first name of the user.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// The last name of the user.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// The role of the user.
        /// </summary>
        public string? Role { get; set; }
    }
}

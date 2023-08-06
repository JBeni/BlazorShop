// <copyright file="AssignUserToRoleCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.UserCommand
{
    /// <summary>
    /// A model to assign an user to role.
    /// </summary>
    public class AssignUserToRoleCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The id of the user.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets The id of the role.
        /// </summary>
        public int RoleId { get; set; }
    }
}

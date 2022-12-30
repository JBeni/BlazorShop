// <copyright file="DeleteRoleCommand.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.RoleCommand
{
    /// <summary>
    /// A model to delete a role.
    /// </summary>
    public class DeleteRoleCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The id of the role.
        /// </summary>
        public int Id { get; set; }
    }
}

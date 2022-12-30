// <copyright file="UpdateRoleCommand.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.RoleCommand
{
    /// <summary>
    /// A model to update a role.
    /// </summary>
    public class UpdateRoleCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The id of the role.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets The name of the role.
        /// </summary>
        public string? Name { get; set; }
    }
}

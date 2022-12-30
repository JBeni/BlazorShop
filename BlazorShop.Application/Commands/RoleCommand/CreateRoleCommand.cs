// <copyright file="CreateRoleCommand.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.RoleCommand
{
    /// <summary>
    /// A model to create a role.
    /// </summary>
    public class CreateRoleCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The name of the role.
        /// </summary>
        public string? Name { get; set; }
    }
}

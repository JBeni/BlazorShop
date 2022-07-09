// <copyright file="CreateRoleCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.RoleCommand
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class CreateRoleCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public string? Name { get; set; }
    }
}

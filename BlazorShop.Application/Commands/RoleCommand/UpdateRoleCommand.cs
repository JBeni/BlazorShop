// <copyright file="UpdateRoleCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.RoleCommand
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class UpdateRoleCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Name { get; set; }
    }
}

// <copyright file="DeleteRoleCommand.cs" author="Beniamin Jitca">
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
        /// The id of the role.
        /// </summary>
        public int Id { get; set; }
    }
}

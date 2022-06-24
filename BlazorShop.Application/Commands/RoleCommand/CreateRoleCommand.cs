// <copyright file="CreateRoleCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.RoleCommand
{
    public class CreateRoleCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public string? Name { get; set; }
    }
}

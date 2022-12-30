// <copyright file="GetRoleByIdQuery.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.RoleQuery
{
    /// <summary>
    /// A model to get the role.
    /// </summary>
    public class GetRoleByIdQuery : IRequest<Result<RoleResponse>>
    {
        /// <summary>
        /// Gets or sets The id of the role.
        /// </summary>
        public int Id { get; set; }
    }
}

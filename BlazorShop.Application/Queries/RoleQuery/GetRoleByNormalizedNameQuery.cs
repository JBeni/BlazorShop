// <copyright file="GetRoleByNormalizedNameQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.RoleQuery
{
    /// <summary>
    /// A model to get the normalized role.
    /// </summary>
    public class GetRoleByNormalizedNameQuery : IRequest<Result<RoleResponse>>
    {
        /// <summary>
        /// Gets or sets The normalized name of the role.
        /// </summary>
        public string? NormalizedName { get; set; }
    }
}

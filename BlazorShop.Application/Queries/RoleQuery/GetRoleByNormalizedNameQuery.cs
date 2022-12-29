// <copyright file="GetRoleByNormalizedNameQuery.cs" author="Beniamin Jitca">
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
        /// The normalized name of the role.
        /// </summary>
        public string? NormalizedName { get; set; }
    }
}

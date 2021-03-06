// <copyright file="GetRoleByNormalizedNameQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.RoleQuery
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetRoleByNormalizedNameQuery : IRequest<Result<RoleResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public string? NormalizedName { get; set; }
    }
}

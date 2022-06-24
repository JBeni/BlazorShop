// <copyright file="GetRoleByIdQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.RoleQuery
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetRoleByIdQuery : IRequest<Result<RoleResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}

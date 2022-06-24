// <copyright file="GetUserByEmailQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.UserQuery
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetUserByEmailQuery : IRequest<Result<UserResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public string? Email { get; set; }
    }
}

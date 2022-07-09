// <copyright file="GetUserByIdQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.UserQuery
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetUserByIdQuery : IRequest<Result<UserResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}

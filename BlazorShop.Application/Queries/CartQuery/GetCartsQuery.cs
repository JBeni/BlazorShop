// <copyright file="GetCartsQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.CartQuery
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetCartsQuery : IRequest<Result<CartResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int UserId { get; set; }
    }
}

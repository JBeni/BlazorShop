// <copyright file="GetCartsQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.CartQuery
{
    /// <summary>
    /// A model to get the carts.
    /// </summary>
    public class GetCartsQuery : IRequest<Result<CartResponse>>
    {
        /// <summary>
        /// Gets or sets The id of the user.
        /// </summary>
        public int UserId { get; set; }
    }
}

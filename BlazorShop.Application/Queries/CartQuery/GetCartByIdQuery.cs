// <copyright file="GetCartByIdQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.CartQuery
{
    /// <summary>
    /// A model to get a cart.
    /// </summary>
    public class GetCartByIdQuery : IRequest<Result<CartResponse>>
    {
        /// <summary>
        /// Gets or sets The id of the cart.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets The id of the user.
        /// </summary>
        public int UserId { get; set; }
    }
}

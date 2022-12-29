// <copyright file="GetCartByIdQuery.cs" author="Beniamin Jitca">
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
        /// The id of the cart.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The id of the user.
        /// </summary>
        public int UserId { get; set; }
    }
}

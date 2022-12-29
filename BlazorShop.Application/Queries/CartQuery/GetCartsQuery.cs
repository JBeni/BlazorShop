// <copyright file="GetCartsQuery.cs" author="Beniamin Jitca">
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
        /// The id of the user.
        /// </summary>
        public int UserId { get; set; }
    }
}

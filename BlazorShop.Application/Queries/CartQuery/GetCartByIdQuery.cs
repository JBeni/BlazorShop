// <copyright file="GetCartByIdQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.CartQuery
{
    public class GetCartByIdQuery : IRequest<Result<CartResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public int UserId { get; set; }
    }
}

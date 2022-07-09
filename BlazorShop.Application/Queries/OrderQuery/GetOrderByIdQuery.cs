// <copyright file="GetOrderByIdQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.OrderQuery
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetOrderByIdQuery : IRequest<Result<OrderResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string UserEmail { get; set; }
    }
}

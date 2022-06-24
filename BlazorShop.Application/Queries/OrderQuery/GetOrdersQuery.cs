// <copyright file="GetOrdersQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.OrderQuery
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetOrdersQuery : IRequest<Result<OrderResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public string UserEmail { get; set; }
    }
}

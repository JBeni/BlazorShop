// <copyright file="GetOrdersQuery.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.OrderQuery
{
    /// <summary>
    /// A model to get the orders.
    /// </summary>
    public class GetOrdersQuery : IRequest<Result<OrderResponse>>
    {
        /// <summary>
        /// The email of the user.
        /// </summary>
        public string UserEmail { get; set; }
    }
}

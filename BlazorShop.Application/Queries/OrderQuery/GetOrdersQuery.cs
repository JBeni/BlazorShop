// <copyright file="GetOrdersQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.OrderQuery
{
    public class GetOrdersQuery : IRequest<Result<OrderResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public string UserEmail { get; set; }
    }
}

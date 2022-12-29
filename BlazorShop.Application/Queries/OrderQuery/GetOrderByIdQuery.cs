// <copyright file="GetOrderByIdQuery.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.OrderQuery
{
    /// <summary>
    /// A model to get the order.
    /// </summary>
    public class GetOrderByIdQuery : IRequest<Result<OrderResponse>>
    {
        /// <summary>
        /// The id of the order.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The email of the user.
        /// </summary>
        public string UserEmail { get; set; }
    }
}

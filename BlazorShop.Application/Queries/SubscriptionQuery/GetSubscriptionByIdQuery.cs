// <copyright file="GetSubscriptionByIdQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.SubscriptionQuery
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetSubscriptionByIdQuery : IRequest<Result<SubscriptionResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}

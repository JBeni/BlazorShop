// <copyright file="GetSubscriptionByIdQuery.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.SubscriptionQuery
{
    /// <summary>
    /// A model to get the subscription.
    /// </summary>
    public class GetSubscriptionByIdQuery : IRequest<Result<SubscriptionResponse>>
    {
        /// <summary>
        /// The id of the subscription.
        /// </summary>
        public int Id { get; set; }
    }
}

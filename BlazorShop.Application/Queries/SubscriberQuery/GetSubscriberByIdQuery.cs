// <copyright file="GetSubscriberByIdQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.SubscriberQuery
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetSubscriberByIdQuery : IRequest<Result<SubscriberResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int UserId { get; set; }
    }
}

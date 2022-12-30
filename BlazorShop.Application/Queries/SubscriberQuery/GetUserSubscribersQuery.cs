// <copyright file="GetUserSubscribersQuery.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.SubscriberQuery
{
    /// <summary>
    /// A model to get the subscribers.
    /// </summary>
    public class GetUserSubscribersQuery : IRequest<Result<SubscriberResponse>>
    {
        /// <summary>
        /// Gets or sets The id of the user.
        /// </summary>
        public int UserId { get; set; }
    }
}

// <copyright file="GetUserSubscribersQuery.cs" author="Beniamin Jitca">
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
        /// The id of the user.
        /// </summary>
        public int UserId { get; set; }
    }
}

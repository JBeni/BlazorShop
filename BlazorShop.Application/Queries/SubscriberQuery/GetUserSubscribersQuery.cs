// <copyright file="GetUserSubscribersQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.SubscriberQuery
{
    public class GetUserSubscribersQuery : IRequest<Result<SubscriberResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int UserId { get; set; }
    }
}

// <copyright file="GetSubscriberByIdQuery.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.SubscriberQuery
{
    /// <summary>
    /// A model to get the subcriber.
    /// </summary>
    public class GetSubscriberByIdQuery : IRequest<Result<SubscriberResponse>>
    {
        /// <summary>
        /// Gets or sets The id of the user.
        /// </summary>
        public int UserId { get; set; }
    }
}

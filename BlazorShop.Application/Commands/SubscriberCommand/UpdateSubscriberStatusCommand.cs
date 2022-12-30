// <copyright file="UpdateSubscriberStatusCommand.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.SubscriberCommand
{
    /// <summary>
    /// A model to update a subscriber status.
    /// </summary>
    public class UpdateSubscriberStatusCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The id of the stripe subscriber subscription.
        /// </summary>
        public string StripeSubscriberSubscriptionId { get; set; }
    }
}

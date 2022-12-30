// <copyright file="CreateSubscriberCommand.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.SubscriberCommand
{
    /// <summary>
    /// A model to create a subscriber.
    /// </summary>
    public class CreateSubscriberCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The id of the subscriber.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets The started date of the subscriber.
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// Gets or sets The date when the current period ends.
        /// </summary>
        public DateTime CurrentPeriodEnd { get; set; }

        /// <summary>
        /// Gets or sets The customer id.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets The subscription id.
        /// </summary>
        public int SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets The id of the stripe subscription.
        /// </summary>
        public string StripeSubscriptionId { get; set; }
    }
}

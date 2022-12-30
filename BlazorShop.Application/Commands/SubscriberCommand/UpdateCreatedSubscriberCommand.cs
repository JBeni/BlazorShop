// <copyright file="UpdateCreatedSubscriberCommand.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.SubscriberCommand
{
    /// <summary>
    /// A model to update a created subscriber.
    /// </summary>
    public class UpdateCreatedSubscriberCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The date when the current period ends.
        /// </summary>
        public DateTime CurrentPeriodEnd { get; set; }

        /// <summary>
        /// Gets or sets The date when the current period starts.
        /// </summary>
        public DateTime CurrentPeriodStart { get; set; }

        /// <summary>
        /// Gets or sets The email of the customer.
        /// </summary>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// Gets or sets The id of the stripe subscriber subscription.
        /// </summary>
        public string StripeSubscriberSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets The url of the invoice.
        /// </summary>
        public string HostedInvoiceUrl { get; set; }
    }
}

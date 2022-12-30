// <copyright file="Subscriber.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Entities
{
    /// <summary>
    /// A template for the entity subscriber.
    /// </summary>
    public class Subscriber : EntityBase
    {
        /// <summary>
        /// Gets or Sets the status of the subscriber.
        /// </summary>
        public SubscriptionStatus Status { get; set; }

        /// <summary>
        /// Gets or Sets the start date of the subscriber.
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// Gets or Sets when the current period of the subscription ends.
        /// </summary>
        public DateTime CurrentPeriodEnd { get; set; }

        /// <summary>
        /// Gets or Sets when the current period of the subscription starts.
        /// </summary>
        public DateTime CurrentPeriodStart { get; set; }

        /// <summary>
        /// Gets or Sets the id of the stripe subscriber subscription.
        /// </summary>
        public string StripeSubscriberSubscriptionId { get; set; }

        /// <summary>
        /// Gets or Sets the invoice url.
        /// </summary>
        public string HostedInvoiceUrl { get; set; }

        /// <summary>
        /// Gets or Sets the customer.
        /// </summary>
        public User Customer { get; set; }

        /// <summary>
        /// Gets or Sets the subscription.
        /// </summary>
        public Subscription Subscription { get; set; }
    }
}

// <copyright file="Subscription.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Entities
{
    /// <summary>
    /// A template for the entity subscription.
    /// </summary>
    public class Subscription : EntityBase
    {
        /// <summary>
        /// Gets or sets the stripe subscription id.
        /// </summary>
        public string StripeSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the subscription.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price of the subscription.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets the currency of the subscription.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the currency symbol of the subscription.
        /// </summary>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets the charge type of the subscription.
        /// </summary>
        public string ChargeType { get; set; }

        /// <summary>
        /// Gets or sets the price of the subscription.
        /// </summary>
        public string Options { get; set; }

        /// <summary>
        /// Gets or sets the image name of the subscription.
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// Gets or sets the image path of the subscription.
        /// </summary>
        public string ImagePath { get; set; }
    }
}

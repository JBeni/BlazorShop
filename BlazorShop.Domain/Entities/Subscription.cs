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
        /// Gets or Sets the stripe subscription id.
        /// </summary>
        public string StripeSubscriptionId { get; set; }

        /// <summary>
        /// Gets or Sets the name of the subscription.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the price of the subscription.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Gets or Sets the currency of the subscription.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or Sets the currency symbol of the subscription.
        /// </summary>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// Gets or Sets the charge type of the subscription.
        /// </summary>
        public string ChargeType { get; set; }

        /// <summary>
        /// Gets or Sets the price of the subscription.
        /// </summary>
        public string Options { get; set; }

        /// <summary>
        /// Gets or Sets the image name of the subscription.
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// Gets or Sets the image path of the subscription.
        /// </summary>
        public string ImagePath { get; set; }
    }
}

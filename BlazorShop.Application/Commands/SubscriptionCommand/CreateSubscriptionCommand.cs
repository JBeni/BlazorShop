// <copyright file="CreateSubscriptionCommand.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.SubscriptionCommand
{
    /// <summary>
    /// A model to create a subscription.
    /// </summary>
    public class CreateSubscriptionCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The id of the subscription.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets The id of the stripe subscription.
        /// </summary>
        public string StripeSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets The name of the subscription.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets The price of the subscription.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets The options of the subscription.
        /// </summary>
        public string Options { get; set; }

        /// <summary>
        /// Gets or sets The image name of the subscription.
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// Gets or sets The image path of the subscription.
        /// </summary>
        public string ImagePath { get; set; }
    }
}

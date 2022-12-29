// <copyright file="UpdateSubscriptionCommand.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.SubscriptionCommand
{
    /// <summary>
    /// A model to update a subscription.
    /// </summary>
    public class UpdateSubscriptionCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// The id of the subscription.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The id of the stripe subscription.
        /// </summary>
        public string StripeSubscriptionId { get; set; }

        /// <summary>
        /// The name of the subscription.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The price of the subscription.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// The options of the subscription.
        /// </summary>
        public string Options { get; set; }

        /// <summary>
        /// The image name of the subscription.
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// The image path of the subscription.
        /// </summary>
        public string ImagePath { get; set; }
	}
}

// <copyright file="UpdateSubscriberStatusCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.SubscriberCommand
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class UpdateSubscriberStatusCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public string StripeSubscriberSubscriptionId { get; set; }
    }
}

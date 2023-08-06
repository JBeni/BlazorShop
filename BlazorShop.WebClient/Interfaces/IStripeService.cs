// <copyright file="IStripeService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interfaces
{
    /// <summary>
    /// The service to interact with the stripe.
    /// </summary>
    public interface IStripeService
    {
        /// <summary>
        /// Cancel the membership.
        /// </summary>
        /// <param name="stripeSubscriptionCreationId">The id of the stripe created subscription.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task CancelMembership(string stripeSubscriptionCreationId);
    }
}

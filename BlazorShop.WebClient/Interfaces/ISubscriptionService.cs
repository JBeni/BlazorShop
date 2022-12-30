// <copyright file="ISubscriptionService.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interfaces
{
    /// <summary>
    /// The service to interact with the subscription.
    /// </summary>
    public interface ISubscriptionService
    {
        /// <summary>
        /// Get the subscriptions.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<SubscriptionResponse>> GetSubscriptions();

        /// <summary>
        /// Get a subscription.
        /// </summary>
        /// <param name="id">The id of the subscription.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<SubscriptionResponse> GetSubscription(int id);

        /// <summary>
        /// Save a subscription.
        /// </summary>
        /// <param name="subscription">The subscription.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<RequestResponse> AddSubscription(SubscriptionResponse subscription);

        /// <summary>
        /// Update a subscription.
        /// </summary>
        /// <param name="subscription">The subscription..</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<RequestResponse> UpdateSubscription(SubscriptionResponse subscription);

        /// <summary>
        /// Delete a subscription.
        /// </summary>
        /// <param name="id">The id of the subscription.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<RequestResponse> DeleteSubscription(int id);
    }
}

// <copyright file="ISubscriberService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interfaces
{
    /// <summary>
    /// The service to interact with the subscriber.
    /// </summary>
    public interface ISubscriberService
    {
        /// <summary>
        /// Get the subscribers.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<List<SubscriberResponse>> GetSubscribers();

        /// <summary>
        /// Get all users subscribers.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<List<SubscriberResponse>> GetUserAllSubscribers(int userId);

        /// <summary>
        /// Get user subscriber.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<SubscriberResponse> GetUserSubscriber(int userId);

        /// <summary>
        /// Add a subscriber.
        /// </summary>
        /// <param name="subscriber">The subscriber.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> AddSubscriber(SubscriberResponse subscriber);

        /// <summary>
        /// Update a subscriber.
        /// </summary>
        /// <param name="subscriber">The subscriber.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> UpdateSubscriber(SubscriberResponse subscriber);

        /// <summary>
        /// Delete a subscriber.
        /// </summary>
        /// <param name="id">The id of the subscriber.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> DeleteSubscriber(int id);
    }
}

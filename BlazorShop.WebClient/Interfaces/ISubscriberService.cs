// <copyright file="ISubscriberService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interfaces
{
    public interface ISubscriberService
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<List<SubscriberResponse>> GetSubscribers();

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<List<SubscriberResponse>> GetUserAllSubscribers(int userId);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<SubscriberResponse> GetUserSubscriber(int userId);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<RequestResponse> AddSubscriber(SubscriberResponse subscriber);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<RequestResponse> UpdateSubscriber(SubscriberResponse subscriber);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<RequestResponse> DeleteSubscriber(int id);
    }
}

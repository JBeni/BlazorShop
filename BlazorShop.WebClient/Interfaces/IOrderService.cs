// <copyright file="IOrderService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interfaces
{
    /// <summary>
    /// The service to interact with the order.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Get the user orders.
        /// </summary>
        /// <param name="userEmail">The email of the user.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<List<OrderResponse>> GetOrders(string userEmail);

        /// <summary>
        /// Get an order.
        /// </summary>
        /// <param name="id">The id of the order.</param>
        /// <param name="userEmail">The email of the user.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<OrderResponse> GetOrder(int id, string userEmail);

        /// <summary>
        /// Add an order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> AddOrder(OrderResponse order);

        /// <summary>
        /// Update an order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> UpdateOrder(OrderResponse order);

        /// <summary>
        /// Delete a role.
        /// </summary>
        /// <param name="id">The id of the order.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> DeleteOrder(int id);
    }
}

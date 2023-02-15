// <copyright file="ICartService.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interfaces
{
    /// <summary>
    /// The service to interact with the cart.
    /// </summary>
    public interface ICartService
    {
        /// <summary>
        /// Get the carts.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<List<CartResponse>> GetCarts(int userId);

        /// <summary>
        /// Get the carts number.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<int> GetCartCounts(int userId);

        /// <summary>
        /// Get a cart.
        /// </summary>
        /// <param name="id">The id of the cart.</param>
        /// <param name="userId">The id of the user.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<CartResponse> GetCart(int id, int userId);

        /// <summary>
        /// Add a cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> AddCart(CartResponse cart);

        /// <summary>
        /// Update a cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> UpdateCart(CartResponse cart);

        /// <summary>
        /// Delete a cart.
        /// </summary>
        /// <param name="id">The id of the cart.</param>
        /// <param name="userId">The id of the user.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> DeleteCart(int id, int userId);

        /// <summary>
        /// Empty the cart.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> EmptyCart(int userId);

        /// <summary>
        /// Checkout the cart.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<string> Checkout(int userId);
    }
}

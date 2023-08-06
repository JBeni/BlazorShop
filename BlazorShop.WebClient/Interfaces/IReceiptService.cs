// <copyright file="IReceiptService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interfaces
{
    /// <summary>
    /// The service to interact with the receipt.
    /// </summary>
    public interface IReceiptService
    {
        /// <summary>
        /// Get the receipts.
        /// </summary>
        /// <param name="userEmail">The user email.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<List<ReceiptResponse>> GetReceipts(string userEmail);

        /// <summary>
        /// Get a receipt.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="userEmail">The user email.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<ReceiptResponse> GetReceipt(int id, string userEmail);

        /// <summary>
        /// Add a receipt.
        /// </summary>
        /// <param name="receipt">The receipt.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> AddReceipt(ReceiptResponse receipt);

        /// <summary>
        /// Update a receipt.
        /// </summary>
        /// <param name="receipt">The receipt.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> UpdateReceipt(ReceiptResponse receipt);

        /// <summary>
        /// Delete a receipt.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> DeleteReceipt(int id);
    }
}

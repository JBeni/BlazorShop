// <copyright file="IClotheService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interfaces
{
    /// <summary>
    /// The service to interact with the clothe.
    /// </summary>
    public interface IClotheService
    {
        /// <summary>
        /// Get the clothes.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<List<ClotheResponse>> GetClothes();

        /// <summary>
        /// Get a clothe.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<ClotheResponse> GetClothe(int id);

        /// <summary>
        /// Add a clothe.
        /// </summary>
        /// <param name="clothe">The clothe.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> AddClothe(ClotheResponse clothe);

        /// <summary>
        /// Update a clothe.
        /// </summary>
        /// <param name="clothe">The clothe.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> UpdateClothe(ClotheResponse clothe);

        /// <summary>
        /// Delete a clothe.
        /// </summary>
        /// <param name="id">The id of the clothe.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> DeleteClothe(int id);
    }
}

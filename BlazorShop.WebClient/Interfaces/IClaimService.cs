// <copyright file="IClaimService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interfaces
{
    /// <summary>
    /// The service to interact with the claim.
    /// </summary>
    public interface IClaimService
    {
        /// <summary>
        /// Get the Claims.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<List<ClaimResponse>> GetClaims();

        /// <summary>
        /// Get a Claim.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<ClaimResponse> GetClaim(int id);

        /// <summary>
        /// Save a Claim.
        /// </summary>
        /// <param name="claim">The Claim.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> AddClaim(ClaimResponse claim);

        /// <summary>
        /// Update a Claim.
        /// </summary>
        /// <param name="claim">The Claim.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> UpdateClaim(ClaimResponse claim);

        /// <summary>
        /// Delete a Claim.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> DeleteClaim(int id);
    }
}

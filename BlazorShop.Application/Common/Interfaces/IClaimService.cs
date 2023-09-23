// <copyright file="IClaimService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Interfaces
{
    /// <summary>
    /// A service to provide Claim features.
    /// </summary>
    public interface IClaimService
    {
        /// <summary>
        /// Check the Claims of an user.
        /// </summary>
        /// <param name="user">The user data.</param>
        /// <returns>A list of user's Claims.</returns>
        Task<List<string>> CheckUserClaimsAsync(User user);

        /// <summary>
        /// Get the user Claim.
        /// </summary>
        /// <returns>The user Claim.</returns>
        ClaimResponse GetUserClaim();

        /// <summary>
        /// Set the Claim to the user.
        /// </summary>
        /// <param name="user">The user data.</param>
        /// <param name="claimValue">The Claim name.</param>
        /// <returns>The request response.</returns>
        Task<RequestResponse> SetUserClaimAsync(User user, string claimValue);

        /// <summary>
        /// Creates a new Claim.
        /// </summary>
        /// <param name="claim">The name of the Claim.</param>
        /// <returns>The created Claim.</returns>
        Task<RequestResponse> CreateClaimAsync(CreateClaimCommand claim);

        /// <summary>
        /// Updates the Claim data.
        /// </summary>
        /// <param name="claim">The Claim data.</param>
        /// <returns>The request response.</returns>
        Task<RequestResponse> UpdateClaimAsync(UpdateClaimCommand claim);

        /// <summary>
        /// Deletes a Claim.
        /// </summary>
        /// <param name="claimId">The id of the Claim.</param>
        /// <returns>The request response.</returns>
        Task<RequestResponse> DeleteClaimAsync(int claimId);

        /// <summary>
        /// Gets all the Claims for a non-admin user.
        /// </summary>
        /// <returns>The list of Claims.</returns>
        List<ClaimResponse> GetClaims();

        /// <summary>
        /// Find the Claim by id.
        /// </summary>
        /// <param name="id">The id of the Claim.</param>
        /// <returns>The Claim data.</returns>
        ClaimResponse GetClaimById(int id);

        /// <summary>
        /// Gets the Claim by value.
        /// </summary>
        /// <param name="claimValue">The value of the Claim.</param>
        /// <returns>The Claim data.</returns>
        ClaimResponse GetClaimByValue(string claimValue);
    }
}

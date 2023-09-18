// <copyright file="IClaimService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Interfaces
{
    /// <summary>
    /// A service for the custom user claims.
    /// </summary>
    public interface ICustomClaimsService
    {
        Task AddUserClaim();

        Task DeleteUserClaim();

        Task UpdateUserClaim();
    }
}

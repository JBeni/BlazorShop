// <copyright file="ICurrentUserService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Interfaces
{
    /// <summary>
    /// A service for current user.
    /// </summary>
    public interface ICurrentUserService
    {
        /// <summary>
        /// Gets the user id.
        /// </summary>
        int UserId { get; }
    }
}

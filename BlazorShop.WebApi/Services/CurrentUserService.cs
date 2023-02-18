// <copyright file="CurrentUserService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using System.Security.Claims;

namespace BlazorShop.WebApi.Services
{
    /// <summary>
    /// An implementation of the <see cref="ICurrentUserService"/> class.
    /// </summary>
    public class CurrentUserService : ICurrentUserService
    {
        /// <summary>
        /// Gets the instance of the <see cref="IHttpContextAccessor"/>.
        /// </summary>
        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentUserService"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">Gets the instance of the <see cref="IHttpContextAccessor"/>.</param>
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Gets the id of the current logged user.
        /// </summary>
        public int UserId => this.GetCurrentUserId();

        /// <summary>
        /// Get the id of the current authenticated user.
        /// </summary>
        /// <returns>An int value.</returns>
        private int GetCurrentUserId()
        {
            int userId = int.Parse(this.httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier));
            return userId;
        }
    }
}

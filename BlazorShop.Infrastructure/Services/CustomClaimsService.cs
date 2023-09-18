// <copyright file="CustomClaimsService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Services
{
    /// <summary>
    /// An implementation of <see cref="ICustomClaimsService"/>.
    /// </summary>
    public class CustomClaimsService : ICustomClaimsService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomClaimsService"/> class.
        /// </summary>
        /// <param name="userManager">The instance of <see cref="UserManager{User}"/> to use.</param>
        public CustomClaimsService(UserManager<User> userManager)
        {
            this.UserManager = userManager;
        }

        /// <summary>
        /// Gets the instance of the <see cref="UserManager{User}"/> to use.
        /// </summary>
        private UserManager<User> UserManager { get; }

        /// <inheritdoc/>
        public Task AddUserClaim()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task DeleteUserClaim()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task UpdateUserClaim()
        {
            throw new NotImplementedException();
        }
    }
}

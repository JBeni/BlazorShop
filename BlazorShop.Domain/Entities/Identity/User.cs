// <copyright file="User.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Entities.Identity
{
    /// <summary>
    /// A template for the entity user.
    /// </summary>
    public class User : IdentityUser<int>
    {
        /// <summary>
        /// .
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public virtual ICollection<UserToken> UserTokens { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public virtual ICollection<UserRole> Roles { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public virtual ICollection<UserLogin> Logins { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public virtual ICollection<UserClaim> Claims { get; set; }
    }
}

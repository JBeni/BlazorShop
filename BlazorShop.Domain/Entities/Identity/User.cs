// <copyright file="User.cs" company="Beniamin Jitca" author="Beniamin Jitca">
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
        /// Gets or Sets the firstname of the user.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or Sets the lastname of the user.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether the user is active or not.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or Sets the user tokens.
        /// </summary>
        public virtual ICollection<UserToken> UserTokens { get; set; }

        /// <summary>
        /// Gets or Sets the user roles.
        /// </summary>
        public virtual ICollection<UserRole> Roles { get; set; }

        /// <summary>
        /// Gets or Sets the user logins.
        /// </summary>
        public virtual ICollection<UserLogin> Logins { get; set; }

        /// <summary>
        /// Gets or Sets the user claims.
        /// </summary>
        public virtual ICollection<UserClaim> Claims { get; set; }
    }
}

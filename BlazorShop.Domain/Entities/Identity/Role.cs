// <copyright file="Role.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Entities.Identity
{
    /// <summary>
    /// A template for the entity role.
    /// </summary>
    public class Role : IdentityRole<int>
    {
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public virtual ICollection<UserRole> Users { get; set; }

        /// <summary>
        /// Gets or sets the users claims.
        /// </summary>
        public virtual ICollection<RoleClaim> Claims { get; set; }
    }
}

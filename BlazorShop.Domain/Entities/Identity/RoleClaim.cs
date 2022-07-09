// <copyright file="RoleClaim.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Entities.Identity
{
    /// <summary>
    /// A template for the entity role claim.
    /// </summary>
    public class RoleClaim : IdentityRoleClaim<int>
    {
        /// <summary>
        /// .
        /// </summary>
        public virtual Role Role { get; set; }
    }
}

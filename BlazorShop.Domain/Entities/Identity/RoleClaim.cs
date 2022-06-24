// <copyright file="RoleClaim.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Entities.Identity
{
    public class RoleClaim : IdentityRoleClaim<int>
    {
        /// <summary>
        /// .
        /// </summary>
        public virtual Role Role { get; set; }
    }
}

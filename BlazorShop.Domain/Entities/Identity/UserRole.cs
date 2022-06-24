// <copyright file="UserRole.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Entities.Identity
{
    public class UserRole : IdentityUserRole<int>
    {
        /// <summary>
        /// .
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public virtual Role Role { get; set; }
    }
}

// <copyright file="UserLogin.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Entities.Identity
{
    public class UserLogin : IdentityUserLogin<int>
    {
        /// <summary>
        /// .
        /// </summary>
        public virtual User User { get; set; }
    }
}

// <copyright file="UserToken.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Entities.Identity
{
    /// <summary>
    /// A template for the entity user token.
    /// </summary>
    public class UserToken : IdentityUserToken<int>
    {
        /// <summary>
        /// Gets or Sets the user.
        /// </summary>
        public virtual User User { get; set; }
    }
}

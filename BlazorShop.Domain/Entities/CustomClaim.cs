// <copyright file="CustomClaim.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Entities
{
    /// <summary>
    /// A custom claim entity.
    /// </summary>
    public class CustomClaim : EntityBase
    {
        /// <summary>
        /// Gets or sets the claim type.
        /// </summary>
        public string ClaimType { get; set; }

        /// <summary>
        /// Gets or sets the claim value.
        /// </summary>
        public string ClaimValue { get; set; }
    }
}

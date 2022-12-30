// <copyright file="JwtTokenConfig.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Models
{
    /// <summary>
    /// A setting model for the JWT token.
    /// </summary>
    public class JwtTokenConfig
    {
        /// <summary>
        /// Gets or sets the JWT secret.
        /// </summary>
        public string? Secret { get; set; }

        /// <summary>
        /// Gets or sets the JWT issuer.
        /// </summary>
        public string? Issuer { get; set; }

        /// <summary>
        /// Gets or sets the JWT audience.
        /// </summary>
        public string? Audience { get; set; }

        /// <summary>
        /// Gets or sets the JWT access token.
        /// </summary>
        public string? AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the JWT refresh token.
        /// </summary>
        public string? RefreshToken { get; set; }
    }
}

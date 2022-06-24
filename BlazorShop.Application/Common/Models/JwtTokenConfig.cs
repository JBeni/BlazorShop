// <copyright file="JwtTokenConfig.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Models
{
    public class JwtTokenConfig
    {
        /// <summary>
        /// .
        /// </summary>
        public string? Secret { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Issuer { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Audience { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? AccessToken { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? RefreshToken { get; set; }
    }
}

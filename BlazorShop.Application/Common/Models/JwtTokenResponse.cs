// <copyright file="JwtTokenResponse.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Models
{
    /// <summary>
    /// A model to create a JWT token.
    /// </summary>
    public class JwtTokenResponse
    {
        /// <summary>
        /// Gets or sets The access token.
        /// </summary>
        [JsonProperty("access_token")]
        public string? AccessToken { get; set; } = null;

        /// <summary>
        /// Gets or sets the scope.
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the expires in.
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// Gets the token type.
        /// </summary>
        public string? Type => "Bearer";

        /// <summary>
        /// Gets or sets A value indicating whether the request was successfully or not.
        /// </summary>
        public bool Successful { get; set; } = false;

        /// <summary>
        /// Gets or sets The error message if the request is not successful.
        /// </summary>
        public string? Error { get; set; } = null;

        /// <summary>
        /// Gets the request response in case of failure.
        /// </summary>
        /// <param name="error">The error message.</param>
        /// <returns>A failure response.</returns>
        public static JwtTokenResponse Failure(string error)
        {
            return new JwtTokenResponse { Error = error };
        }
    }
}

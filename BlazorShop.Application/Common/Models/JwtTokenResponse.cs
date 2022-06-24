// <copyright file="JwtTokenResponse.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Models
{
    public class JwtTokenResponse
    {
        /// <summary>
        /// .
        /// </summary>
        public string? Access_Token { get; set; } = null;

        /// <summary>
        /// .
        /// </summary>
        public string? Type => "Bearer";

        /// <summary>
        /// .
        /// </summary>
        public int Expires_In { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public bool Successful { get; set; } = false;

        /// <summary>
        /// .
        /// </summary>
        public string? Error { get; set; } = null;

        /// <summary>
        /// .
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static JwtTokenResponse Failure(string error)
        {
            return new JwtTokenResponse { Error = error };
        }
    }
}

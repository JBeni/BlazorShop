// <copyright file="JwtTokenMiddleware.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using System.IdentityModel.Tokens.Jwt;

namespace BlazorShop.WebApi.Filters
{
    /// <summary>
    /// A middleware to intercept the JWT token.
    /// </summary>
    public class JwtTokenMiddleware
    {
        /// <summary>
        /// .
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// .
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// .
        /// </summary>
        /// <param name="next"></param>
        /// <param name="configuration"></param>
        public JwtTokenMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext httpContext)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null && !IsCurrentTokenValid(token))
            {
                httpContext.Request.Headers["Authorization"] = "";
            }

            await _next(httpContext);
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        private bool IsCurrentTokenValid(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var isTokenValid = true;

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.FromSeconds(1),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.Unicode.GetBytes(_configuration["JwtToken:SecretKey"])),
                    RequireSignedTokens = true,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidAudience = _configuration["JwtToken:Audience"],
                    ValidIssuer = _configuration["JwtToken:Issuer"]
                }, out SecurityToken validatedToken);
            }
            catch (Exception)
            {
                isTokenValid = false;
            }

            return isTokenValid;
        }
    }
}

// <copyright file="JwtTokenMiddleware.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Filters
{
    /// <summary>
    /// A middleware to intercept the JWT token.
    /// </summary>
    public class JwtTokenMiddleware
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JwtTokenMiddleware"/> class.
        /// </summary>
        /// <param name="next">The instance of the <see cref="RequestDelegate"/> to use.</param>
        /// <param name="configuration">The instance of the <see cref="IConfiguration"/> to use.</param>
        public JwtTokenMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            this.Next = next;
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the instance of the <see cref="RequestDelegate"/> to use.
        /// </summary>
        private RequestDelegate Next { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IConfiguration"/> to use.
        /// </summary>
        private IConfiguration Configuration { get; }

        /// <summary>
        /// The method running every time a request its being made to the server.
        /// </summary>
        /// <param name="httpContext">The http context.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Invoke(HttpContext httpContext)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null && !this.IsCurrentTokenValid(token))
            {
                httpContext.Request.Headers["Authorization"] = string.Empty;
            }

            await this.Next(httpContext);
        }

        /// <summary>
        /// Validating the bearer token validity.
        /// </summary>
        /// <param name="token">The bearer token data.</param>
        /// <returns>A boolean value.</returns>
        private bool IsCurrentTokenValid(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var isTokenValid = true;

            try
            {
                #pragma warning disable SA1117 // Parameters should be on same line or separate lines
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.FromSeconds(1),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.Unicode.GetBytes(this.Configuration["JwtToken:SecretKey"])),
                    RequireSignedTokens = true,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidAudience = this.Configuration["JwtToken:Audience"],
                    ValidIssuer = this.Configuration["JwtToken:Issuer"],
                }, validatedToken: out SecurityToken validatedToken);
                #pragma warning restore SA1117 // Parameters should be on same line or separate lines
            }
            catch (Exception)
            {
                isTokenValid = false;
            }

            return isTokenValid;
        }
    }
}

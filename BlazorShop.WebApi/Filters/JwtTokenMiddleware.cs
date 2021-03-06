// <copyright file="JwtTokenMiddleware.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Filters
{
    /// <summary>
    /// A middleware to intercept the JWT token.
    /// </summary>
    public class JwtTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            var user = context.User.Identity.Name;
            var role = context.User.IsInRole(StringRoleResources.Admin);

            await _next(context);
        }
    }
}

// <copyright file="IAuthenticationService.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Auth
{
    /// <summary>
    /// A service responsible for the account functionalities.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<JwtTokenResponse> Login(LoginCommand userForAuthenticatrion);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<JwtTokenResponse> Register(RegisterCommand userForAuthenticatrion);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task Logout();
    }
}

// <copyright file="IAuthenticationService.cs" company="Beniamin Jitca" author="Beniamin Jitca">
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
        /// Authenticate the user.
        /// </summary>
        /// <param name="userForAuthenticatrion">The login command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<JwtTokenResponse> Login(LoginCommand userForAuthenticatrion);

        /// <summary>
        /// Register the user.
        /// </summary>
        /// <param name="userForAuthenticatrion">The register command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<JwtTokenResponse> Register(RegisterCommand userForAuthenticatrion);

        /// <summary>
        /// Logout the user from the app.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Logout();
    }
}

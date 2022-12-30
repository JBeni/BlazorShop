// <copyright file="IAccountService.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Interfaces
{
    /// <summary>
    /// A service to provide Account features.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Reset the password of the user.
        /// </summary>
        /// <param name="resetPassword">The reset password object.</param>
        /// <returns>The request response.</returns>
        Task<RequestResponse> ResetPasswordUserAsync(ResetPasswordCommand resetPassword);

        /// <summary>
        /// Change the user password.
        /// </summary>
        /// <param name="changePassword">The change password object.</param>
        /// <returns>The request response.</returns>
        Task<RequestResponse> ChangePasswordUserAsync(ChangePasswordCommand changePassword);

        /// <summary>
        /// Generate a Bearer token to access the application.
        /// </summary>
        /// <param name="user">The user object.</param>
        /// <returns>The created JWT token.</returns>
        Task<JwtTokenResponse> GenerateToken(User user);

        /// <summary>
        /// Log in the user.
        /// </summary>
        /// <param name="login">The login object.</param>
        /// <returns>The created JWT token.</returns>
        Task<JwtTokenResponse> LoginAsync(LoginCommand login);

        /// <summary>
        /// Creates a new account for the user.
        /// </summary>
        /// <param name="register">The register object.</param>
        /// <returns>The created JWT token.</returns>
        Task<JwtTokenResponse> RegisterAsync(RegisterCommand register);

        /// <summary>
        /// Checking the user password validity.
        /// </summary>
        /// <param name="user">The user object.</param>
        /// <param name="password">The password data.</param>
        /// <returns>A boolean value.</returns>
        Task<bool> CheckPasswordAsync(User user, string password);
    }
}

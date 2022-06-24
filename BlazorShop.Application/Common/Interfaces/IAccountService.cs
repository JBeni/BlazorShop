// <copyright file="IAccountService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Interfaces
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task<RequestResponse> ResetPasswordUserAsync(ResetPasswordCommand resetPassword);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task<RequestResponse> ChangePasswordUserAsync(ChangePasswordCommand changePassword);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task<JwtTokenResponse> GenerateToken(User user);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task<JwtTokenResponse> LoginAsync(LoginCommand login);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task<JwtTokenResponse> RegisterAsync(RegisterCommand register);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task<bool> CheckPasswordAsync(User user, string password);
    }
}

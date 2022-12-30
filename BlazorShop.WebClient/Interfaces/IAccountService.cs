// <copyright file="IAccountService.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interfaces
{
    /// <summary>
    /// The service to interact with the account.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Change the password.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<RequestResponse> ChangePassword(ChangePasswordCommand command);

        /// <summary>
        /// Reset the user password.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<RequestResponse> ResetPassword(ResetPasswordCommand command);
    }
}

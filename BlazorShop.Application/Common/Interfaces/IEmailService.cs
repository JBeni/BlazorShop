// <copyright file="IEmailService.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Interfaces
{
    /// <summary>
    /// A service for handling the emails.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Sending the emails.
        /// </summary>
        /// <param name="email">The email address where to send the email.</param>
        /// <param name="mail">The mail body.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task SendEmail(string? email, EmailSettings mail);
    }
}

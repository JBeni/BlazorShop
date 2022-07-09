// <copyright file="IEmailService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Interfaces
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task SendEmail(string? email, EmailSettings mail);
    }
}

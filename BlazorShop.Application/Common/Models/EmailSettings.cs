// <copyright file="EmailSettings.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Models
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class EmailSettings
    {
        /// <summary>
        /// .
        /// </summary>
        public string? Host { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Subject { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Password { get; set; }
    }
}

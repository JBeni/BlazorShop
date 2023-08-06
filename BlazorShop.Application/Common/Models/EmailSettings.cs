// <copyright file="EmailSettings.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Models
{
    /// <summary>
    /// A setting model for the Email.
    /// </summary>
    public class EmailSettings
    {
        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        public string? Host { get; set; }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        public string? Subject { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string? Password { get; set; }
    }
}

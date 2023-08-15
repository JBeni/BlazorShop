// <copyright file="AdminSeedModel.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Utils
{
    /// <summary>
    /// A model of Admin user details.
    /// </summary>
    public class AdminSeedModel
    {
        /// <summary>
        /// Gets or sets the firstname.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the lastname.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets the role name.
        /// </summary>
        public string? RoleName { get; set; }
    }
}

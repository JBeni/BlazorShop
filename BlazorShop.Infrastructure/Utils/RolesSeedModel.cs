// <copyright file="RolesSeedModel.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Utils
{
    /// <summary>
    /// A model of Roles seed.
    /// </summary>
    public class RolesSeedModel
    {
        /// <summary>
        /// Gets or sets the admin role name.
        /// </summary>
        public string? AdminRoleName { get; set; }

        /// <summary>
        /// Gets or sets the admin normalized role name.
        /// </summary>
        public string? AdminRoleNormalizedName { get; set; }

        /// <summary>
        /// Gets or sets the default role name.
        /// </summary>
        public string? DefaultRoleName { get; set; }

        /// <summary>
        /// Gets or sets the default normalized role name.
        /// </summary>
        public string? DefaultRoleNormalizedName { get; set; }

        /// <summary>
        /// Gets or sets the user role name.
        /// </summary>
        public string? UserRoleName { get; set; }

        /// <summary>
        /// Gets or sets the user normalized role name.
        /// </summary>
        public string? UserRoleNormalizedName { get; set; }
    }
}

// <copyright file="RolesSeedModel.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Utils
{
    /// <summary>
    /// A model of Roles seed.
    /// </summary>
    public class RolesSeedModel
    {
        public string? AdminRoleName { get; set; }
        public string? AdminRoleNormalizedName { get; set; }
        public string? DefaultRoleName { get; set; }
        public string? DefaultRoleNormalizedName { get; set; }
        public string? UserRoleName { get; set; }
        public string? UserRoleNormalizedName { get; set; }
    }
}

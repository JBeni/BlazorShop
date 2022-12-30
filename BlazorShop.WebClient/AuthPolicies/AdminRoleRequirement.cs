// <copyright file="AdminRoleRequirement.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.AuthPolicies
{
    /// <summary>
    /// A custom policy to check for the Admin role.
    /// </summary>
    public class AdminRoleRequirement : IAuthorizationRequirement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdminRoleRequirement"/> class.
        /// </summary>
        /// <param name="role">The role name.</param>
        public AdminRoleRequirement(string role)
        {
            this.Role = role;
        }

        /// <summary>
        /// Gets the role name.
        /// </summary>
        public string Role { get; }
    }
}

// <copyright file="UserRoleRequirement.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.AuthPolicies
{
    /// <summary>
    /// A custom policy to check for the User role.
    /// </summary>
    public class UserRoleRequirement : IAuthorizationRequirement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleRequirement"/> class.
        /// </summary>
        /// <param name="role">The role name.</param>
        public UserRoleRequirement(string role)
        {
            this.Role = role;
        }

        /// <summary>
        /// Gets the role name.
        /// </summary>
        public string Role { get; }
    }
}

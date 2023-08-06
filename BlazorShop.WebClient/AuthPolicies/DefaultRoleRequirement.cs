// <copyright file="DefaultRoleRequirement.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.AuthPolicies
{
    /// <summary>
    /// A custom policy to check for the Default role.
    /// </summary>
    public class DefaultRoleRequirement : IAuthorizationRequirement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultRoleRequirement"/> class.
        /// </summary>
        /// <param name="role">The role name.</param>
        public DefaultRoleRequirement(string role)
        {
            this.Role = role;
        }

        /// <summary>
        /// Gets the role name.
        /// </summary>
        public string Role { get; }
    }
}

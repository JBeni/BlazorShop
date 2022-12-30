// <copyright file="CustomerRoleRequirement.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.AuthPolicies
{
    /// <summary>
    /// A custom policy to check for the Customer role.
    /// </summary>
    public class CustomerRoleRequirement : IAuthorizationRequirement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRoleRequirement"/> class.
        /// </summary>
        public CustomerRoleRequirement()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRoleRequirement"/> class.
        /// </summary>
        /// <param name="role">The role name.</param>
        public CustomerRoleRequirement(string role)
        {
            this.Role = role;
        }

        /// <summary>
        /// Gets the role name.
        /// </summary>
        public string Role { get; }
    }
}

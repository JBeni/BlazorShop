// <copyright file="IRoleService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Interfaces
{
    /// <summary>
    /// A service to provide Role features.
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// Check the roles of an user.
        /// </summary>
        /// <param name="user">The user data.</param>
        /// <returns>A list of user's roles.</returns>
        Task<List<string>> CheckUserRolesAsync(User user);

        /// <summary>
        /// Gets the default role.
        /// </summary>
        /// <returns>The default entity role.</returns>
        RoleResponse GetDefaultRole();

        /// <summary>
        /// Get the user role.
        /// </summary>
        /// <returns>The user role.</returns>
        RoleResponse GetUserRole();

        /// <summary>
        /// Gets the admin role.
        /// </summary>
        /// <returns>The admin role.</returns>
        RoleResponse GetAdminRole();

        /// <summary>
        /// Set the role to the user.
        /// </summary>
        /// <param name="user">The user data.</param>
        /// <param name="role">The role name.</param>
        /// <returns>The request response.</returns>
        Task<RequestResponse> SetUserRoleAsync(User user, string role);

        /// <summary>
        /// Finding the role by id.
        /// </summary>
        /// <param name="roleId">The id of the role.</param>
        /// <returns>The role data.</returns>
        Task<Role> FindRoleByIdAsync(int roleId);

        /// <summary>
        /// Search the roles by name.
        /// </summary>
        /// <param name="name">The name of the role.</param>
        /// <returns>The role.</returns>
        Task<Role> FindRoleByNameAsync(string name);

        /// <summary>
        /// Creates a new role.
        /// </summary>
        /// <param name="role">The name of the role.</param>
        /// <returns>The created role.</returns>
        Task<RequestResponse> CreateRoleAsync(CreateClaimCommand role);

        /// <summary>
        /// Updates the role data.
        /// </summary>
        /// <param name="role">The role data.</param>
        /// <returns>The request response.</returns>
        Task<RequestResponse> UpdateRoleAsync(UpdateClaimCommand role);

        /// <summary>
        /// Deletes a role.
        /// </summary>
        /// <param name="roleId">The id of the role.</param>
        /// <returns>The request response.</returns>
        Task<RequestResponse> DeleteRoleAsync(int roleId);

        /// <summary>
        /// Gets all the roles for a non-admin user.
        /// </summary>
        /// <returns>The list of roles.</returns>
        List<RoleResponse> GetRoles();

        /// <summary>
        /// Gets all the roles for admin user.
        /// </summary>
        /// <returns>The list of roles.</returns>
        List<RoleResponse> GetRolesForAdmin();

        /// <summary>
        /// Find the role by id.
        /// </summary>
        /// <param name="id">The id of the role.</param>
        /// <returns>The role data.</returns>
        RoleResponse GetRoleById(int id);

        /// <summary>
        /// Gets the role by normalized name.
        /// </summary>
        /// <param name="normalizedName">The normalized name of the role.</param>
        /// <returns>The role data.</returns>
        RoleResponse GetRoleByNormalizedName(string normalizedName);
    }
}

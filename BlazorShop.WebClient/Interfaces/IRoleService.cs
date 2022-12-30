// <copyright file="IRoleService.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interfaces
{
    /// <summary>
    /// The service to interact with the role.
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// Get the roles.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<RoleResponse>> GetRoles();

        /// <summary>
        /// Get the admin roles.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<RoleResponse>> GetRolesForAdmin();

        /// <summary>
        /// Get a role.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<RoleResponse> GetRole(int id);

        /// <summary>
        /// Save a role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<RequestResponse> AddRole(RoleResponse role);

        /// <summary>
        /// Update a role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<RequestResponse> UpdateRole(RoleResponse role);

        /// <summary>
        /// Delete a role.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<RequestResponse> DeleteRole(int id);
    }
}

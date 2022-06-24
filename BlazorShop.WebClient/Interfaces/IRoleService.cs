// <copyright file="IRoleService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interfaces
{
    public interface IRoleService
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<List<RoleResponse>> GetRoles();

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<List<RoleResponse>> GetRolesForAdmin();

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<RoleResponse> GetRole(int id);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<RequestResponse> AddRole(RoleResponse role);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<RequestResponse> UpdateRole(RoleResponse role);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<RequestResponse> DeleteRole(int id);
    }
}

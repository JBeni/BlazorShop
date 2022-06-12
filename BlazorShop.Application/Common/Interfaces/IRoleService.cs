namespace BlazorShop.Application.Common.Interfaces
{
    public interface IRoleService
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task<List<string>> CheckUserRolesAsync(User user);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        RoleResponse GetDefaultRole();

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        RoleResponse GetUserRole();

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        RoleResponse GetAdminRole();

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task<RequestResponse> SetUserRoleAsync(User user, string role);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task<Role> FindRoleByIdAsync(int roleId);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task<Role> FindRoleByNameAsync(string name);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task<RequestResponse> CreateRoleAsync(CreateRoleCommand role);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task<RequestResponse> UpdateRoleAsync(UpdateRoleCommand role);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task<RequestResponse> DeleteRoleAsync(int roleId);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        List<RoleResponse> GetRoles();

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        List<RoleResponse> GetRolesForAdmin();

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        RoleResponse GetRoleById(int id);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        RoleResponse GetRoleByNormalizedName(string normalizedName);
    }
}

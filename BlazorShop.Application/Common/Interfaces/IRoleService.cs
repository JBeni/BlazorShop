namespace BlazorShop.Application.Common.Interfaces
{
    public interface IRoleService
    {
        Task<List<string>> CheckUserRolesAsync(User user);
        RoleResponse GetDefaultRole();
        RoleResponse GetUserRole();
        RoleResponse GetAdminRole();
        Task<RequestResponse> SetUserRoleAsync(User user, string role);
        Task<Role> FindRoleByIdAsync(int roleId);
        Task<Role> FindRoleByNameAsync(string name);

        Task<RequestResponse> CreateRoleAsync(CreateRoleCommand role);
        Task<RequestResponse> UpdateRoleAsync(UpdateRoleCommand role);
        Task<RequestResponse> DeleteRoleAsync(int roleId);
        List<RoleResponse> GetRoles();
        RoleResponse GetRoleById(int id);
        RoleResponse GetRoleByNormalizedName(string normalizedName);
    }
}

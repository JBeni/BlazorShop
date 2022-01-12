namespace BlazorShop.Application.Common.Interfaces
{
    public interface IRoleService
    {
        Task<List<string>> CheckUserRolesAsync(AppUser user);
        RoleResponse GetDefaultRole();
        RoleResponse GetUserRole();
        RoleResponse GetAdminRole();
        Task<RequestResponse> SetUserRoleAsync(AppUser user, string role);
        Task<AppRole> FindRoleByIdAsync(int roleId);
        Task<AppRole> FindRoleByNameAsync(string name);

        Task<RequestResponse> CreateRoleAsync(CreateRoleCommand role);
        Task<RequestResponse> UpdateRoleAsync(UpdateRoleCommand role);
        Task<RequestResponse> DeleteRoleAsync(int roleId);
        List<RoleResponse> GetRoles();
        RoleResponse GetRoleById(int id);
        RoleResponse GetRoleByNormalizedName(string normalizedName);
    }
}

namespace BlazorShop.Application.Common.Interfaces
{
    public interface IAppRoleService
    {
        Task<List<string>> CheckUserRolesAsync(AppUser user);
        AppRoleResponse GetDefaultRole();
        AppRoleResponse GetUserRole();
        AppRoleResponse GetAdminRole();
        Task<RequestResponse> SetUserRoleAsync(AppUser user, string role);
        Task<AppRole> FindRoleByIdAsync(int roleId);
        Task<AppRole> FindRoleByNameAsync(string name);

        Task<RequestResponse> CreateRoleAsync(CreateRoleCommand role);
        Task<RequestResponse> UpdateRoleAsync(UpdateRoleCommand role);
        Task<RequestResponse> DeleteRoleAsync(int roleId);
        List<AppRoleResponse> GetRoles();
        AppRoleResponse GetRoleById(int id);
        AppRoleResponse GetRoleByNormalizedName(string normalizedName);
    }
}

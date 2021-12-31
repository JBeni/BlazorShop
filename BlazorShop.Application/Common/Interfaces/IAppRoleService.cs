namespace BlazorShop.Application.Common.Interfaces
{
    public interface IAppRoleService
    {
        Task<List<string?>> CheckUserRolesAsync(AppUser user);
        AppRoleResponse GetDefaultRole();
        AppRoleResponse GetAdminRole();
        Task<RequestResponse> SetUserRoleAsync(AppUser user, string? role);
    }
}

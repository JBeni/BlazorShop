namespace BlazorShop.WebClient.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleResponse>> GetRoles();
        Task<RoleResponse> GetRole(int id);
        Task AddRole(RoleResponse Role);
        Task UpdateRole(RoleResponse Role);
        Task DeleteRole(int id);
    }
}

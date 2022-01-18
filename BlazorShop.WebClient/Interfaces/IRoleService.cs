namespace BlazorShop.WebClient.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleResponse>> GetRoles();
        Task<RoleResponse> GetRole(int id);
        Task<RequestResponse> AddRole(RoleResponse Role);
        Task<RequestResponse> UpdateRole(RoleResponse Role);
        Task<RequestResponse> DeleteRole(int id);
    }
}

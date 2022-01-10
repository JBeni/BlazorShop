namespace BlazorShop.WebClient.Services
{
    public class RoleService : IRoleService
    {
        private readonly HttpClient _httpClient;

        public RoleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddRole(RoleResponse role)
        {
            await _httpClient.PostAsJsonAsync($"Roles/role", role);
        }

        public async Task DeleteRole(int id)
        {
            await _httpClient.GetAsync($"Roles/role/{id}");
        }

        public async Task<RoleResponse> GetRole(int id)
        {
            var authResult = await _httpClient.GetAsync($"Roles/role/{id}");
            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RoleResponse>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task<List<RoleResponse>> GetRoles()
        {
            var authResult = await _httpClient.GetAsync("Roles/roles");
            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<RoleResponse>>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task UpdateRole(RoleResponse role)
        {
            await _httpClient.PutAsJsonAsync($"Roles/role", role);
        }
    }
}

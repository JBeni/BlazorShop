namespace BlazorShop.WebClient.Services
{
    public class RoleService : IRoleService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;

        public RoleService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
        }

        public async Task AddRole(RoleResponse role)
        {
            var response = await _httpClient.PostAsJsonAsync($"Roles/role", role);

            if (!response.IsSuccessStatusCode) _toastService.ShowError("Something went wrong.");
            _toastService.ShowSuccess("The role was added.");
        }

        public async Task DeleteRole(int id)
        {
            var response = await _httpClient.DeleteAsync($"Roles/role/{id}");

            if (!response.IsSuccessStatusCode) _toastService.ShowError("Something went wrong.");
            _toastService.ShowSuccess("The role was deleted.");
        }

        public async Task<RoleResponse> GetRole(int id)
        {
            var authResult = await _httpClient.GetAsync($"Roles/role/{id}");
            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RoleResponse>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
            if (!authResult.IsSuccessStatusCode) _toastService.ShowError("Something went wrong.");

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
            if (!authResult.IsSuccessStatusCode) _toastService.ShowError("Something went wrong.");

            return result;
        }

        public async Task UpdateRole(RoleResponse role)
        {
            var data = new UpdateRoleCommand
            {
                Id = role.Id,
                Name = role.Name,
            };
            var response = await _httpClient.PutAsJsonAsync($"Roles/role", data);

            if (!response.IsSuccessStatusCode) _toastService.ShowError("Something went wrong.");
            _toastService.ShowSuccess("The role was updated.");
        }
    }
}

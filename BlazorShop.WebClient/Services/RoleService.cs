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

        public async Task<RequestResponse> AddRole(RoleResponse role)
        {
            var response = await _httpClient.PostAsJsonAsync($"Roles/role", role);
            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            _toastService.ShowSuccess("The role was added.");
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteRole(int id)
        {
            var response = await _httpClient.DeleteAsync($"Roles/role/{id}");
            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            _toastService.ShowSuccess("The role was deleted.");
            return RequestResponse.Success();
        }

        public async Task<RoleResponse> GetRole(int id)
        {
            var authResult = await _httpClient.GetAsync($"Roles/role/{id}");
            if (authResult.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

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
            if (authResult.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<RoleResponse>>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task<RequestResponse> UpdateRole(RoleResponse role)
        {
            var data = new UpdateRoleCommand
            {
                Id = role.Id,
                Name = role.Name,
            };
            var response = await _httpClient.PutAsJsonAsync($"Roles/role", data);
            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            _toastService.ShowSuccess("The role was updated.");
            return RequestResponse.Success();
        }
    }
}

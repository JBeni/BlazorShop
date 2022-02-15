namespace BlazorShop.WebClient.Services
{
    public class RoleService : IRoleService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;
        private readonly JsonSerializerOptions _options;

        public RoleService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<RequestResponse> AddRole(RoleResponse role)
        {
            var response = await _httpClient.PostAsJsonAsync($"Roles/role", role);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The role was added.");
            return result;
        }

        public async Task<RequestResponse> DeleteRole(int id)
        {
            var response = await _httpClient.DeleteAsync($"Roles/role/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The role was deleted.");
            return result;
        }

        public async Task<RoleResponse> GetRole(int id)
        {
            var response = await _httpClient.GetAsync($"Roles/role/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<RoleResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            return result.Item;
        }

        public async Task<List<RoleResponse>> GetRoles()
        {
            var response = await _httpClient.GetAsync("Roles/roles");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<RoleResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            return result.Items;
        }

        public async Task<List<RoleResponse>> GetRolesForAdmin()
        {
            var response = await _httpClient.GetAsync("Roles/rolesAdmin");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<RoleResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            return result.Items;
        }

        public async Task<RequestResponse> UpdateRole(RoleResponse role)
        {
            var data = new UpdateRoleCommand
            {
                Id = role.Id,
                Name = role.Name,
            };
            var response = await _httpClient.PutAsJsonAsync($"Roles/role", data);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The role was updated.");
            return result;
        }
    }
}

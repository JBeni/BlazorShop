namespace BlazorShop.WebClient.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;

        public UserService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
        }

        public async Task AddUser(UserResponse user)
        {
            var data = new CreateUserCommand
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.RoleName
            };
            var response = await _httpClient.PostAsJsonAsync($"Users/user", data);

            if (!response.IsSuccessStatusCode) _toastService.ShowError("Something went wrong.");
            _toastService.ShowSuccess("The user was added.");
        }

        public async Task DeleteUser(int id)
        {
            var response = await _httpClient.DeleteAsync($"Users/user/{id}");

            if (!response.IsSuccessStatusCode) _toastService.ShowError("Something went wrong.");
            _toastService.ShowSuccess("The user was deleted.");
        }

        public async Task<UserResponse> GetUser(int id)
        {
            var authResult = await _httpClient.GetAsync($"Users/user/{id}");
            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<UserResponse>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
            if (!authResult.IsSuccessStatusCode) _toastService.ShowError("Something went wrong.");

            return result;
        }

        public async Task<List<UserResponse>> GetUsers()
        {
            var authResult = await _httpClient.GetAsync("Users/users");
            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<UserResponse>>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
            if (!authResult.IsSuccessStatusCode) _toastService.ShowError("Something went wrong.");

            return result;
        }

        public async Task<RequestResponse> UpdateUser(UserResponse user)
        {
            var data = new UpdateUserCommand
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.RoleName
            };

            var response = await _httpClient.PutAsJsonAsync($"Users/user", data);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                    content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

            if (!response.IsSuccessStatusCode) _toastService.ShowError("Something went wrong.");
            _toastService.ShowSuccess("The user was updated.");

            return result;
        }

        public async Task<RequestResponse> UpdateUserEmail(UpdateUserEmailCommand user)
        {
            var response = await _httpClient.PutAsJsonAsync($"Users/userEmail", user);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                    content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

            if (!response.IsSuccessStatusCode) _toastService.ShowError("Something went wrong.");
            _toastService.ShowSuccess("The user email address was updated.");

            return result;
        }
    }
}

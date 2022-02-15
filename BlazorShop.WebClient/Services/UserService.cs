namespace BlazorShop.WebClient.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;
        private readonly JsonSerializerOptions _options;

        public UserService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<RequestResponse> AddUser(UserResponse user)
        {
            var data = new CreateUserCommand
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.RoleName
            };

            var response = await _httpClient.PostAsJsonAsync($"Users/user", data);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The user was added.");
            return result;
        }

        public async Task<RequestResponse> ActivateUser(int userId)
        {
            var data = new ActivateUserCommand
            {
                Id = userId
            };

            var response = await _httpClient.PostAsJsonAsync($"Users/userActivate", data);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The user was activated.");
            return result;
        }

        public async Task<RequestResponse> DeleteUser(int id)
        {
            var response = await _httpClient.DeleteAsync($"Users/user/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The user was deleted.");
            return result;
        }

        public async Task<UserResponse> GetUser(int id)
        {
            var response = await _httpClient.GetAsync($"Users/user/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<UserResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            return result.Item;
        }

        public async Task<List<UserResponse>> GetUsers()
        {
            var response = await _httpClient.GetAsync("Users/users");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<UserResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            return result.Items;
        }

        public async Task<List<UserResponse>> GetUsersInactive()
        {
            var response = await _httpClient.GetAsync("Users/usersInactive");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<UserResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            return result.Items;
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
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The user was updated.");
            return result;
        }

        public async Task<RequestResponse> UpdateUserEmail(UpdateUserEmailCommand user)
        {
            var response = await _httpClient.PutAsJsonAsync($"Users/userEmail", user);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The user email address was updated.");
            return result;
        }
    }
}

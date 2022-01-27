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
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<ErrorView>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                _toastService.ShowError(resultError.Title + ": " + resultError.Detail);
                return null;
            }

            _toastService.ShowSuccess("The user was added.");
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteUser(int id)
        {
            var response = await _httpClient.DeleteAsync($"Users/user/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<ErrorView>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                _toastService.ShowError(resultError.Title + ": " + resultError.Detail);
                return null;
            }

            _toastService.ShowSuccess("The user was deleted.");
            return RequestResponse.Success();
        }

        public async Task<UserResponse> GetUser(int id)
        {
            var response = await _httpClient.GetAsync($"Users/user/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<ErrorView>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                _toastService.ShowError(resultError.Title + ": " + resultError.Detail);
                return null;
            }

            var result = JsonSerializer.Deserialize<UserResponse>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task<List<UserResponse>> GetUsers()
        {
            var response = await _httpClient.GetAsync("Users/users");
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<ErrorView>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                _toastService.ShowError(resultError.Title + ": " + resultError.Detail);
                return null;
            }

            var result = JsonSerializer.Deserialize<List<UserResponse>>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

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
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<ErrorView>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                _toastService.ShowError(resultError.Title + ": " + resultError.Detail);
                return null;
            }

            var result = JsonSerializer.Deserialize<RequestResponse>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

            _toastService.ShowSuccess("The user was updated.");
            return result;
        }

        public async Task<RequestResponse> UpdateUserEmail(UpdateUserEmailCommand user)
        {
            var response = await _httpClient.PutAsJsonAsync($"Users/userEmail", user);
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<ErrorView>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                _toastService.ShowError(resultError.Title + ": " + resultError.Detail);
                return null;
            }

            var result = JsonSerializer.Deserialize<RequestResponse>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

            _toastService.ShowSuccess("The user email address was updated.");
            return result;
        }
    }
}

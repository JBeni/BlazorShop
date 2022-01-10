namespace BlazorShop.WebClient.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddUser(UserResponse user)
        {
            await _httpClient.PostAsJsonAsync($"Users/user", user);
        }

        public async Task DeleteUser(int id)
        {
            await _httpClient.GetAsync($"Users/user/{id}");
        }

        public async Task<UserResponse> GetUser(int id)
        {
            var authResult = await _httpClient.GetAsync($"Users/user/{id}");
            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<UserResponse>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

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

            return result;
        }

        public async Task UpdateUser(UserResponse user)
        {
            await _httpClient.PutAsJsonAsync($"Users/user", user);
        }
    }
}

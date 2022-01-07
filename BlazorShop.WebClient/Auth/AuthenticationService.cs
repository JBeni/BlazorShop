namespace BlazorShop.WebClient.Auth;

public class AuthenticationService : IAuthenticationService
{
    private readonly HttpClient _httpClient;
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly ILocalStorageService _localStorage;

    public AuthenticationService(HttpClient httpClient,
                                 AuthenticationStateProvider authStateProvider,
                                 ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _authStateProvider = authStateProvider;
        _localStorage = localStorage;
    }

    public async Task<JwtAccessToken> Login(LoginCommand command)
    {
        var data = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("email", command.Email),
            new KeyValuePair<string, string>("password", command.Password),
        });
        var authResult = await _httpClient.PostAsync("Accounts/login", data);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode == false)
        {
            return null;
        }
        var result = JsonSerializer.Deserialize<JwtAccessToken>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
        if (result.Access_Token == null)
        {
            return null;
        }

        await _localStorage.SetItemAsync("authToken", result.Access_Token);
        ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.Access_Token);

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(result.Type, result.Access_Token);
        return new JwtAccessToken { Access_Token = result.Access_Token };
    }

    public async Task<JwtAccessToken> Register(RegisterCommand command)
    {
        var data = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("email", command.Email),
            new KeyValuePair<string, string>("password", command.Password),
        });
        var authResult = await _httpClient.PostAsync("Accounts/register", data);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode == false)
        {
            return null;
        }
        var result = JsonSerializer.Deserialize<JwtAccessToken>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
        if (result.Access_Token == null)
        {
            return null;
        }

        await _localStorage.SetItemAsync("authToken", result.Access_Token);
        ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.Access_Token);

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(result.Type, result.Access_Token);
        return new JwtAccessToken { Access_Token = result.Access_Token };
    }

    public async Task<List<AppRoleResponse>> GetRoles()
    {
        var authResult = await _httpClient.GetAsync("AppRoles/roles");
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode == false)
        {
            return null;
        }
        var result = JsonSerializer.Deserialize<List<AppRoleResponse>>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

        return result;
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }
}

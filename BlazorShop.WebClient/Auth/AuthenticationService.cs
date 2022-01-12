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

    public async Task<JwtTokenResponse> Login(LoginCommand command)
    {
        var data = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("Email", command.Email),
            new KeyValuePair<string, string>("Password", command.Password),
        });
        var authResult = await _httpClient.PostAsync("Accounts/login", data);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode == false)
        {
            return null;
        }
        var result = JsonSerializer.Deserialize<JwtTokenResponse>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
        if (result.Access_Token == null)
        {
            return null;
        }

        await _localStorage.SetItemAsync("authToken", result.Access_Token.ToString());
        ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.Access_Token.ToString());

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(result.Type, result.Access_Token.ToString());
        return new JwtTokenResponse { Access_Token = result.Access_Token.ToString() };
    }

    public async Task<JwtTokenResponse> Register(RegisterCommand command)
    {
        var data = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("Email", command.Email),
            new KeyValuePair<string, string>("FirstName", command.FirstName),
            new KeyValuePair<string, string>("LastName", command.LastName),
            new KeyValuePair<string, string>("RoleName", command.RoleName),
            new KeyValuePair<string, string>("Password", command.Password),
            new KeyValuePair<string, string>("ConfirmPassword", command.ConfirmPassword),
        });
        var authResult = await _httpClient.PostAsync("Accounts/register", data);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode == false)
        {
            return null;
        }
        var result = JsonSerializer.Deserialize<JwtTokenResponse>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
        if (result.Access_Token == null)
        {
            return null;
        }

        await _localStorage.SetItemAsync("authToken", result.Access_Token.ToString());
        ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.Access_Token.ToString());

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(result.Type, result.Access_Token.ToString());

        return new JwtTokenResponse { Access_Token = result.Access_Token.ToString() };
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }
}

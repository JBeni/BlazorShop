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

    public async Task<JwtAccessToken> Login(LoginCommand userForAuthenticatrion)
    {
        var data = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("grant_type", "password"),
            new KeyValuePair<string, string>("email", userForAuthenticatrion.Email),
            new KeyValuePair<string, string>("password", userForAuthenticatrion.Password),
        });
        var authResult = await _httpClient.PostAsync("https://localhost:44351/api/account/login", data);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode == false)
        {
            return null;
        }
        var result = JsonSerializer.Deserialize<JwtAccessToken>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );


        //var response = await _accountService.LoginAsync(userForAuthenticatrion);
        //if (!response.Successful)
        //{
        //    return null;
        //}

        await _localStorage.SetItemAsync("authToken", result.Access_Token);
        ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.Access_Token);

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(result.Type, result.Access_Token);
        return new JwtAccessToken { Access_Token = result.Access_Token };
    }

    public async Task<JwtAccessToken> Register(RegisterCommand userForAuthenticatrion)
    {
        //var response = await _accountService.RegisterAsync(userForAuthenticatrion);
        //if (!response.Successful)
        //{
        //    return null;
        //}

        //await _localStorage.SetItemAsync("authToken", response.Access_Token);
        //((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(response.Access_Token);

        //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", response.Access_Token);

        //return new JwtAccessToken { Access_Token = response.Access_Token };

        return new JwtAccessToken { Access_Token = "" };
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }
}

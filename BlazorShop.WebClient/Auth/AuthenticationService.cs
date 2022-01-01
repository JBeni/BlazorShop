namespace Blazor.Server.Auth;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAccountService _accountService;
    private readonly HttpClient _httpClient;
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly ILocalStorageService _localStorage;

    public AuthenticationService(HttpClient httpClient, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage, IAccountService accountService)
    {
        _httpClient = httpClient;
        _authStateProvider = authStateProvider;
        _localStorage = localStorage;
        _accountService = accountService;
    }

    public async Task<JwAccessToken> Login(LoginCommand userForAuthenticatrion)
    {
        var response = await _accountService.LoginAsync(userForAuthenticatrion);
        if (!response.Successful)
        {
            return null;
        }

        await _localStorage.SetItemAsync("authToken", response.Access_Token);
        ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(response.Access_Token);

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", response.Access_Token);

        return new JwAccessToken { Access_Token = response.Access_Token };
    }

    public async Task<JwAccessToken> Register(RegisterCommand userForAuthenticatrion)
    {
        var response = await _accountService.RegisterAsync(userForAuthenticatrion);
        if (!response.Successful)
        {
            return null;
        }

        await _localStorage.SetItemAsync("authToken", response.Access_Token);
        ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(response.Access_Token);

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", response.Access_Token);

        return new JwAccessToken { Access_Token = response.Access_Token };
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }
}

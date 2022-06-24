// <copyright file="AuthenticationService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Auth;

public class AuthenticationService : IAuthenticationService
{
    private readonly HttpClient _httpClient;
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly ILocalStorageService _localStorage;
    private readonly IToastService _toastService;

    public AuthenticationService(HttpClient httpClient,
                                 AuthenticationStateProvider authStateProvider,
                                 ILocalStorageService localStorage,
                                 IToastService toastService)
    {
        _httpClient = httpClient;
        _authStateProvider = authStateProvider;
        _localStorage = localStorage;
        _toastService = toastService;
    }

    /// <inheritdoc/>
    public async Task<JwtTokenResponse> Login(LoginCommand command)
    {
        var data = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("Email", command.Email),
            new KeyValuePair<string, string>("Password", command.Password),
        });

        var response = await _httpClient.PostAsync("Accounts/login", data);
        var responseResult = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<JwtTokenResponse>(
            responseResult,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );

        if (response.IsSuccessStatusCode == false)
        {
            _toastService.ShowError(result.Error);
            return null;
        }
        if (result.Access_Token == null)
        {
            _toastService.ShowError("Access Token is null");
            return null;
        }

        await _localStorage.SetItemAsync("authToken", result.Access_Token.ToString());
        ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.Access_Token.ToString());

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(result.Type, result.Access_Token.ToString());
        return new JwtTokenResponse { Access_Token = result.Access_Token.ToString() };
    }

    /// <inheritdoc/>
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

        var response = await _httpClient.PostAsync("Accounts/register", data);
        var responseResult = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<JwtTokenResponse>(
            responseResult,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );
        if (response.IsSuccessStatusCode == false)
        {
            _toastService.ShowError(result.Error);
            return null;
        }

        if (result.Access_Token == null)
        {
            _toastService.ShowError("Access Token is null");
            return null;
        }

        await _localStorage.SetItemAsync("authToken", result.Access_Token.ToString());
        ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.Access_Token.ToString());

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(result.Type, result.Access_Token.ToString());

        return new JwtTokenResponse { Access_Token = result.Access_Token.ToString() };
    }

    /// <inheritdoc/>
    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }
}

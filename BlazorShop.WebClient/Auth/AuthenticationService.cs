// <copyright file="AuthenticationService.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Auth;

/// <summary>
/// An implementation of <see cref="IAuthenticationService"/>.
/// </summary>
public class AuthenticationService : IAuthenticationService
{
    /// <summary>
    /// .
    /// </summary>
    private readonly HttpClient _httpClient;

    /// <summary>
    /// .
    /// </summary>
    private readonly AuthenticationStateProvider _authStateProvider;

    /// <summary>
    /// .
    /// </summary>
    private readonly ILocalStorageService _localStorage;

    /// <summary>
    /// .
    /// </summary>
    private readonly IToastService _toastService;

    /// <summary>
    /// .
    /// </summary>
    /// <param name="httpClient"></param>
    /// <param name="authStateProvider"></param>
    /// <param name="localStorage"></param>
    /// <param name="toastService"></param>
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

        JwtTokenResponse? jwtResponse = null;
        if (response.IsSuccessStatusCode == false)
        {
            _toastService.ShowError(result.Error);
        }
        else if (result.AccessToken == null)
        {
            _toastService.ShowError("Access Token is null");
        }
        else
        {
            await _localStorage.SetItemAsync("authToken", result.AccessToken.ToString());
            ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.AccessToken.ToString());

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(result.Type, result.AccessToken.ToString());
            jwtResponse = new JwtTokenResponse { AccessToken = result.AccessToken.ToString() };
        }

        return jwtResponse;
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

        JwtTokenResponse? jwtResponse = null;
        if (response.IsSuccessStatusCode == false)
        {
            _toastService.ShowError(result.Error);
        }
        else if (result.AccessToken == null)
        {
            _toastService.ShowError("Access Token is null");
        }
        else
        {
            await _localStorage.SetItemAsync("authToken", result.AccessToken.ToString());
            ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.AccessToken.ToString());

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(result.Type, result.AccessToken.ToString());
            jwtResponse = new JwtTokenResponse { AccessToken = result.AccessToken.ToString() };
        }

        return jwtResponse;
    }

    /// <inheritdoc/>
    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }
}

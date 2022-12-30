// <copyright file="AuthenticationService.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Auth;

/// <summary>
/// An implementation of <see cref="IAuthenticationService"/>.
/// </summary>
public class AuthenticationService : IAuthenticationService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuthenticationService"/> class.
    /// </summary>
    /// <param name="httpClient">The instance of the <see cref="HttpClient"/> to use.</param>
    /// <param name="authStateProvider">The instance of the <see cref="AuthenticationStateProvider"/> to use.</param>
    /// <param name="localStorage">The instance of the <see cref="ILocalStorageService"/> to use.</param>
    /// <param name="toastService">The instance of the <see cref="IToastService"/> to use.</param>
    public AuthenticationService(
        HttpClient httpClient,
        AuthenticationStateProvider authStateProvider,
        ILocalStorageService localStorage,
        IToastService toastService)
    {
        this.HttpClient = httpClient;
        this.AuthStateProvider = authStateProvider;
        this.LocalStorage = localStorage;
        this.ToastService = toastService;
    }

    /// <summary>
    /// Gets the instance of the <see cref="HttpClient"/> to use.
    /// </summary>
    private HttpClient HttpClient { get; }

    /// <summary>
    /// Gets the instance of the <see cref="AuthenticationStateProvider"/> to use.
    /// </summary>
    private AuthenticationStateProvider AuthStateProvider { get; }

    /// <summary>
    /// Gets the instance of the <see cref="ILocalStorageService"/> to use.
    /// </summary>
    private ILocalStorageService LocalStorage { get; }

    /// <summary>
    /// Gets the instance of the <see cref="IToastService"/> to use.
    /// </summary>
    private IToastService ToastService { get; }

    /// <inheritdoc/>
    public async Task<JwtTokenResponse> Login(LoginCommand command)
    {
        var data = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("Email", command.Email),
            new KeyValuePair<string, string>("Password", command.Password),
        });

        var response = await this.HttpClient.PostAsync("Accounts/login", data);
        var responseResult = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<JwtTokenResponse>(
            responseResult,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        JwtTokenResponse? jwtResponse = null;
        if (response.IsSuccessStatusCode == false)
        {
            this.ToastService.ShowError(result.Error);
        }
        else if (result.AccessToken == null)
        {
            this.ToastService.ShowError("Access Token is null");
        }
        else
        {
            await this.LocalStorage.SetItemAsync("authToken", result.AccessToken.ToString());
            ((AuthStateProvider)this.AuthStateProvider).NotifyUserAuthentication(result.AccessToken.ToString());

            this.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(result.Type, result.AccessToken.ToString());
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

        var response = await this.HttpClient.PostAsync("Accounts/register", data);
        var responseResult = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<JwtTokenResponse>(
            responseResult,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        JwtTokenResponse? jwtResponse = null;
        if (response.IsSuccessStatusCode == false)
        {
            this.ToastService.ShowError(result.Error);
        }
        else if (result.AccessToken == null)
        {
            this.ToastService.ShowError("Access Token is null");
        }
        else
        {
            await this.LocalStorage.SetItemAsync("authToken", result.AccessToken.ToString());
            ((AuthStateProvider)this.AuthStateProvider).NotifyUserAuthentication(result.AccessToken.ToString());

            this.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(result.Type, result.AccessToken.ToString());
            jwtResponse = new JwtTokenResponse { AccessToken = result.AccessToken.ToString() };
        }

        return jwtResponse;
    }

    /// <inheritdoc/>
    public async Task Logout()
    {
        await this.LocalStorage.RemoveItemAsync("authToken");
        ((AuthStateProvider)this.AuthStateProvider).NotifyUserLogout();
        this.HttpClient.DefaultRequestHeaders.Authorization = null;
    }
}

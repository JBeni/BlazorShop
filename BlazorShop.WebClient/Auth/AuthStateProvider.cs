// <copyright file="AuthStateProvider.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Auth
{
    /// <summary>
    /// A service to use the authentication state provider.
    /// </summary>
    public class AuthStateProvider : AuthenticationStateProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthStateProvider"/> class.
        /// </summary>
        /// <param name="httpClient">The instance of the <see cref="HttpClient"/> to use.</param>
        /// <param name="localStorage">The instance of the <see cref="ILocalStorageService"/> to use.</param>
        /// <param name="navMagager">The instance of the <see cref="NavigationManager"/> to use.</param>
        public AuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage, NavigationManager navMagager)
        {
            this.HttpClient = httpClient;
            this.LocalStorage = localStorage;
            this.Anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            this.NavMagager = navMagager;
        }

        /// <summary>
        /// Gets the instance of the <see cref="HttpClient"/> to use.
        /// </summary>
        private HttpClient HttpClient { get; }

        /// <summary>
        /// Gets the instance of the <see cref="ILocalStorageService"/> to use.
        /// </summary>
        private ILocalStorageService LocalStorage { get; }

        /// <summary>
        /// Gets the instance of the <see cref="AuthenticationState"/> to use.
        /// </summary>
        private AuthenticationState Anonymous { get; }

        /// <summary>
        /// Gets the instance of the <see cref="NavigationManager"/> to use.
        /// </summary>
        private NavigationManager NavMagager { get; }

        /// <summary>
        /// Authenticate the user if the user its not authenticated.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await this.LocalStorage.GetItemAsync<string>("authToken");

            AuthenticationState? authenticationState;
            if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(this.HttpClient.DefaultRequestHeaders.Authorization?.Parameter))
            {
                this.NotifyUserLogout();
                authenticationState = this.Anonymous;
            }
            else
            {
                this.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.ToString());
                authenticationState = new AuthenticationState(
                        new ClaimsPrincipal(new ClaimsIdentity(JwtTokenParser.ParseClaimsFromJwt(token), "jwtAuthType")));
            }

            return authenticationState;
        }

        /// <summary>
        /// Notify the app that the user is authenticated.
        /// </summary>
        /// <param name="token">The bearer token value.</param>
        public void NotifyUserAuthentication(string token)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(JwtTokenParser.ParseClaimsFromJwt(token), "jwtAuthType"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            this.NotifyAuthenticationStateChanged(authState);
        }

        /// <summary>
        /// Logout the user and notify the application state.
        /// </summary>
        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(this.Anonymous);
            this.NotifyAuthenticationStateChanged(authState);
        }
    }
}

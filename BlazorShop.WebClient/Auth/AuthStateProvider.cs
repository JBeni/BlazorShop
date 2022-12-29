// <copyright file="AuthStateProvider.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BlazorShop.WebClient.Auth
{
    /// <summary>
    /// A service to use the authentication state provider.
    /// </summary>
    public class AuthStateProvider : AuthenticationStateProvider
    {
        /// <summary>
        /// .
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// .
        /// </summary>
        private readonly ILocalStorageService _localStorage;

        /// <summary>
        /// .
        /// </summary>
        private readonly AuthenticationState _anonymous;

        /// <summary>
        /// .
        /// </summary>
        private readonly NavigationManager _navMagager;

        /// <summary>
        /// .
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="localStorage"></param>
        /// <param name="navMagager"></param>
        public AuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage, NavigationManager navMagager)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            _navMagager = navMagager;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");

            AuthenticationState? authenticationState;
            if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(_httpClient.DefaultRequestHeaders.Authorization?.Parameter))
            {
                this.NotifyUserLogout();
                authenticationState = _anonymous;
            }
            else
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.ToString());
                authenticationState = new AuthenticationState(
                        new ClaimsPrincipal(new ClaimsIdentity(JwtTokenParser.ParseClaimsFromJwt(token), "jwtAuthType"))
                    );
            }

            return authenticationState;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        public void NotifyUserAuthentication(string token)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(JwtTokenParser.ParseClaimsFromJwt(token), "jwtAuthType"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(_anonymous);
            NotifyAuthenticationStateChanged(authState);
        }
    }
}

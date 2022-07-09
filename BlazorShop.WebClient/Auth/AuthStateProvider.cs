// <copyright file="AuthStateProvider.cs" company="Beniamin Jitca">
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
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationState _anonymous;
        private readonly IConfiguration _configuration;
        private readonly NavigationManager _navMagager;

        public AuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage, IConfiguration configuration, NavigationManager navMagager)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            _configuration = configuration;
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

            AuthenticationState? authenticationState = _anonymous;
            if (string.IsNullOrWhiteSpace(token) || !this.IsCurrentTokenValid(token))
            {
                this.NotifyUserLogout();
                _navMagager.NavigateTo("/login");
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

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        private bool IsCurrentTokenValid(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var isTokenValid = true;

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.FromSeconds(1),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtToken:SecretKey"])),
                    RequireSignedTokens = true,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidAudience = _configuration["JwtToken:Audience"],
                    ValidIssuer = _configuration["JwtToken:Issuer"]
                }, out SecurityToken validatedToken);
            }
            catch
            {
                isTokenValid = false;
            }

            return isTokenValid;
        }
    }
}

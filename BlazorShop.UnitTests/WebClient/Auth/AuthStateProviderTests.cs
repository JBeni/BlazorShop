// <copyright file="AuthStateProviderTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.WebClient.Auth
{
    /// <summary>
    /// Tests for <see cref="AuthStateProvider"/> class.
    /// </summary>
    public class AuthStateProviderTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthStateProviderTests"/> class.
        /// </summary>
        public AuthStateProviderTests()
        {
            this.Anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

            this.AuthStateProvider = new AuthStateProvider(
                this.HttpClient,
                this.LocalStorage,
                this.NavMagager);
        }

        /// <summary>
        /// Gets the instance of the <see cref="AuthStateProvider"/> to use.
        /// </summary>
        private AuthStateProvider AuthStateProvider { get; }

        /// <summary>
        /// Gets the instance of the <see cref="System.Net.Http.HttpClient"/> to use.
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
        /// A test for <see cref="AuthStateProvider.GetAuthenticationStateAsync()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetAuthenticationStateAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="AuthStateProvider.NotifyUserAuthentication(string)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task NotifyUserAuthentication()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="AuthStateProvider.NotifyUserLogout()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task NotifyUserLogout()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// Ensure garbage collector.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

// <copyright file="AuthenticationServiceTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.WebClient.Auth
{
    /// <summary>
    /// Tests for <see cref="AuthenticationService"/> class.
    /// </summary>
    public class AuthenticationServiceTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationServiceTests"/> class.
        /// </summary>
        public AuthenticationServiceTests()
        {
            this.AuthenticationService = new AuthenticationService(
                this.HttpClient,
                this.AuthStateProvider,
                this.LocalStorage,
                this.ToastService);
        }

        /// <summary>
        /// Gets the instance of the <see cref="AuthenticationService"/> to use.
        /// </summary>
        private AuthenticationService AuthenticationService { get; }

        /// <summary>
        /// Gets the instance of the <see cref="System.Net.Http.HttpClient"/> to use.
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

        /// <summary>
        /// A test for <see cref="AuthenticationService.Login(LoginCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Login()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="AuthenticationService.Register(RegisterCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Register()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="AuthenticationService.Logout()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Logout()
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

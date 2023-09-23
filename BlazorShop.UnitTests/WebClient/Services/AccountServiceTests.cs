// <copyright file="AccountServiceTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using AccountService = BlazorShop.WebClient.Services.AccountService;

namespace BlazorShop.UnitTests.WebClient.Services
{
    /// <summary>
    /// Tests for <see cref="BlazorShop.WebClient.Services.RoleService"/> class.
    /// </summary>
    public class AccountServiceTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountServiceTests"/> class.
        /// </summary>
        public AccountServiceTests()
        {
            this.AccountService = new AccountService(
                this.HttpClient,
                this.SnackBar);
        }

        /// <summary>
        /// Gets the instance of the <see cref="AccountService"/> to use.
        /// </summary>
        private AccountService AccountService { get; }

        /// <summary>
        /// Gets the instance of the <see cref="System.Net.Http.HttpClient"/> to use.
        /// </summary>
        private HttpClient HttpClient { get; } = Mock.Of<HttpClient>();

        /// <summary>
        /// Gets the instance of the <see cref="ISnackbar"/> to use.
        /// </summary>
        private ISnackbar SnackBar { get; } = Mock.Of<ISnackbar>();

        /// <summary>
        /// Gets the instance of the <see cref="JsonSerializerOptions"/> to use.
        /// </summary>
        private JsonSerializerOptions Options { get; }

        /// <summary>
        /// A test for <see cref="AccountService.ChangePassword(ChangePasswordCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task ChangePassword()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="AccountService.ResetPassword(ResetPasswordCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task ResetPassword()
        {
            await Task.CompletedTask;
        }
    }
}

// <copyright file="StripeServiceTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using StripeService = BlazorShop.WebClient.Services.StripeService;

namespace BlazorShop.UnitTests.WebClient.Services
{
    /// <summary>
    /// Tests for <see cref="BlazorShop.WebClient.Services.RoleService"/> class.
    /// </summary>
    public class StripeServiceTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StripeServiceTests"/> class.
        /// </summary>
        public StripeServiceTests()
        {
            this.StripeService = new StripeService(
                this.HttpClient,
                this.SnackBar);
        }

        /// <summary>
        /// Gets the instance of the <see cref="StripeService"/> to use.
        /// </summary>
        private StripeService StripeService { get; }

        /// <summary>
        /// Gets the instance of the <see cref="HttpClient"/> to use.
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
        /// A test for <see cref="StripeService.CancelMembership(string)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CancelMembership()
        {
            await Task.CompletedTask;
        }
    }
}

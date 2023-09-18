// <copyright file="ReceiptServiceTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using ReceiptService = BlazorShop.WebClient.Services.ReceiptService;

namespace BlazorShop.UnitTests.WebClient.Services
{
    /// <summary>
    /// Tests for <see cref="BlazorShop.WebClient.Services.ReceiptService"/> class.
    /// </summary>
    public class ReceiptServiceTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptServiceTests"/> class.
        /// </summary>
        public ReceiptServiceTests()
        {
            this.ReceiptService = new ReceiptService(
                this.HttpClient,
                this.SnackBar);
        }

        /// <summary>
        /// Gets the instance of the <see cref="ReceiptService"/> to use.
        /// </summary>
        private ReceiptService ReceiptService { get; }

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
        /// A test for <see cref="ReceiptService.GetReceipts(string)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetReceipts()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="ReceiptService.GetReceipt(int, string)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetReceipt()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="ReceiptService.AddReceipt(ReceiptResponse)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task AddReceipt()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="ReceiptService.UpdateReceipt(ReceiptResponse)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateReceipt()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="ReceiptService.DeleteReceipt(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteReceipt()
        {
            await Task.CompletedTask;
        }
    }
}

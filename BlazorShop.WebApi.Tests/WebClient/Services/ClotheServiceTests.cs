// <copyright file="ClotheServiceTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using ClotheService = BlazorShop.WebClient.Services.ClotheService;

namespace BlazorShop.UnitTests.WebClient.Services
{
    /// <summary>
    /// Tests for <see cref="BlazorShop.WebClient.Services.ClotheService"/> class.
    /// </summary>
    public class ClotheServiceTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClotheServiceTests"/> class.
        /// </summary>
        public ClotheServiceTests()
        {
            this.ClotheService = new ClotheService(
                this.HttpClient,
                this.SnackBar);
        }

        /// <summary>
        /// Gets the instance of the <see cref="ClotheService"/> to use.
        /// </summary>
        private ClotheService ClotheService { get; }

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
        /// A test for <see cref="ClotheService.GetClothes()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetClothes()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="ClotheService.GetClothe(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetClothe()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="ClotheService.AddClothe(ClotheResponse)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task AddClothe()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="ClotheService.UpdateClothe(ClotheResponse)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateClothe()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="ClotheService.DeleteClothe(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteClothe()
        {
            await Task.CompletedTask;
        }
    }
}

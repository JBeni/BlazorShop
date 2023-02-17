// <copyright file="SessionStorageServiceTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using SessionStorageService = BlazorShop.WebClient.Services.SessionStorageService;

namespace BlazorShop.UnitTests.WebClient.Services
{
    /// <summary>
    /// Tests for <see cref="BlazorShop.WebClient.Services.SessionStorageService"/> class.
    /// </summary>
    public class SessionStorageServiceTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionStorageServiceTests"/> class.
        /// </summary>
        public SessionStorageServiceTests()
        {
            this.SessionStorageService = new SessionStorageService(this.JsInProcess);
        }

        /// <summary>
        /// Gets the instance of the <see cref="SessionStorageService"/> to use.
        /// </summary>
        private SessionStorageService SessionStorageService { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IJSRuntime"/> to use..
        /// </summary>
        private IJSRuntime Js { get; } = Mock.Of<IJSRuntime>();

        /// <summary>
        /// Gets the instance of the <see cref="IJSInProcessRuntime"/> to use..
        /// </summary>
        private IJSInProcessRuntime JsInProcess { get; } = Mock.Of<IJSInProcessRuntime>();

        /// <summary>
        /// A test for <see cref="SessionStorageService.GetItemAsync{T}(string)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetItemAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="SessionStorageService.SetItemAsync{T}(string, T)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task SetItemAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="SessionStorageService.SetItem{T}(string, T)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task SetItem()
        {
            await Task.CompletedTask;
        }
    }
}

// <copyright file="HttpInterceptorServiceTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.WebClient.Interceptor
{
    /// <summary>
    /// Tests for <see cref="HttpInterceptorService"/> class.
    /// </summary>
    public class HttpInterceptorServiceTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpInterceptorServiceTests"/> class.
        /// </summary>
        public HttpInterceptorServiceTests()
        {
            this.HttpInterceptorService = new HttpInterceptorService(
                this.Interceptor,
                this.NavManager);
        }

        /// <summary>
        /// Gets the instance of the <see cref="HttpInterceptorService"/> to use.
        /// </summary>
        private HttpInterceptorService HttpInterceptorService { get; }

        /// <summary>
        /// Gets the instance of the <see cref="HttpClientInterceptor"/> to use.
        /// </summary>
        private HttpClientInterceptor Interceptor { get; } = Mock.Of<HttpClientInterceptor>();

        /// <summary>
        /// Gets the instance of the <see cref="NavigationManager"/> to use.
        /// </summary>
        private NavigationManager NavManager { get; } = Mock.Of<NavigationManager>();

        /// <summary>
        /// A test for <see cref="HttpInterceptorService.RegisterEvent()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task RegisterEvent()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="HttpInterceptorService.DisposeEvent()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DisposeEvent()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="HttpInterceptorService.InterceptResponse(object, HttpClientInterceptorEventArgs)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task InterceptResponse()
        {
            await Task.CompletedTask;
        }
    }
}

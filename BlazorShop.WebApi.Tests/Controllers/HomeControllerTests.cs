// <copyright file="HomeControllerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Controllers
{
    /// <summary>
    /// Tests for <see cref="HomeController"/> class.
    /// </summary>
    public class HomeControllerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeControllerTests"/> class.
        /// </summary>
        public HomeControllerTests()
        {
            this.HomeController = new HomeController(
                this.WebHostEnvironment,
                this.Mediator);
        }

        /// <summary>
        /// Gets the instance of the <see cref="HomeController"/> to use.
        /// </summary>
        private HomeController HomeController { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IWebHostEnvironment"/> to use.
        /// </summary>
        private IWebHostEnvironment WebHostEnvironment { get; } = Mock.Of<IWebHostEnvironment>();

        /// <summary>
        /// Gets the instance of the <see cref="IMediator"/> to use.
        /// </summary>
        private IMediator Mediator { get; } = Mock.Of<IMediator>();

        /// <summary>
        /// A test for <see cref="HomeController.Index()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Index()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="HomeController.Home()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Home()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="HomeController.Error()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Error()
        {
            await Task.CompletedTask;
        }
    }
}

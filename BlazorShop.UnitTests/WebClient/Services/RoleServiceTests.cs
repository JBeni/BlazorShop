// <copyright file="RoleServiceTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using RoleService = BlazorShop.WebClient.Services.RoleService;

namespace BlazorShop.UnitTests.WebClient.Services
{
    /// <summary>
    /// Tests for <see cref="BlazorShop.WebClient.Services.RoleService"/> class.
    /// </summary>
    public class RoleServiceTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleServiceTests"/> class.
        /// </summary>
        public RoleServiceTests()
        {
            this.RoleService = new RoleService(
                this.HttpClient,
                this.SnackBar);
        }

        /// <summary>
        /// Gets the instance of the <see cref="RoleService"/> to use.
        /// </summary>
        private RoleService RoleService { get; }

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
        /// A test for <see cref="RoleService.AddRole(RoleResponse)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task AddRole()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="RoleService.DeleteRole(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteRole()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="RoleService.GetRole(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetRole()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="RoleService.GetRoles()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetRoles()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="RoleService.GetRolesForAdmin()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetRolesForAdmin()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="RoleService.UpdateRole(RoleResponse)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateRole()
        {
            await Task.CompletedTask;
        }
    }
}

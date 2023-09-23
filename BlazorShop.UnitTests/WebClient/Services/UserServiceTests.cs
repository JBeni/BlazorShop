// <copyright file="UserServiceTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using UserService = BlazorShop.WebClient.Services.UserService;

namespace BlazorShop.UnitTests.WebClient.Services
{
    /// <summary>
    /// Tests for <see cref="BlazorShop.WebClient.Services.UserService"/> class.
    /// </summary>
    public class UserServiceTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserServiceTests"/> class.
        /// </summary>
        public UserServiceTests()
        {
            this.UserService = new UserService(
                this.HttpClient,
                this.SnackBar);
        }

        /// <summary>
        /// Gets the instance of the <see cref="UserService"/> to use.
        /// </summary>
        private UserService UserService { get; }

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
        /// A test for <see cref="UserService.AddUser(UserResponse)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task AddUser()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UserService.ActivateUser(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task ActivateUser()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UserService.DeleteUser(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteUser()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UserService.GetUser(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetUser()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UserService.GetUsers()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetUsers()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UserService.GetUsersInactive()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetUsersInactive()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UserService.UpdateUser(UserResponse)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UserService.UpdateUserEmail(UpdateUserEmailCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUserEmail()
        {
            await Task.CompletedTask;
        }
    }
}

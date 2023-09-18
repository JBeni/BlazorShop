// <copyright file="TodoItemServiceTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using TodoItemService = BlazorShop.WebClient.Services.TodoItemService;

namespace BlazorShop.UnitTests.WebClient.Services
{
    /// <summary>
    /// Tests for <see cref="BlazorShop.WebClient.Services.RoleService"/> class.
    /// </summary>
    public class TodoItemServiceTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TodoItemServiceTests"/> class.
        /// </summary>
        public TodoItemServiceTests()
        {
            this.TodoItemService = new TodoItemService(
                this.HttpClient,
                this.SnackBar);
        }

        /// <summary>
        /// Gets the instance of the <see cref="TodoItemService"/> to use.
        /// </summary>
        private TodoItemService TodoItemService { get; }

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
        /// A test for <see cref="TodoItemService.GetTodoItemAsync(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetTodoItemAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="TodoItemService.PutTodoItemAsync(TodoItemResponse)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task PutTodoItemAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="TodoItemService.DeleteTodoItemAsync(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteTodoItemAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="TodoItemService.PostTodoItemAsync(TodoItemResponse)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task PostTodoItemAsync()
        {
            await Task.CompletedTask;
        }
    }
}

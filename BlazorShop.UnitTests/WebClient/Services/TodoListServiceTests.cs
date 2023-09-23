// <copyright file="TodoListServiceTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using TodoListService = BlazorShop.WebClient.Services.TodoListService;

namespace BlazorShop.UnitTests.WebClient.Services
{
    /// <summary>
    /// Tests for <see cref="BlazorShop.WebClient.Services.TodoListService"/> class.
    /// </summary>
    public partial class TodoListServiceTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TodoListServiceTests"/> class.
        /// </summary>
        public TodoListServiceTests()
        {
            this.TodoListService = new TodoListService(
                this.HttpClient,
                this.SnackBar);
        }

        /// <summary>
        /// Gets the instance of the <see cref="TodoListService"/> to use.
        /// </summary>
        private TodoListService TodoListService { get; }

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
        /// A test for <see cref="TodoListService.GetTodoListsAsync()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetTodoListsAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="TodoListService.GetTodoListAsync(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetTodoListAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="TodoListService.PostTodoListAsync(TodoListResponse)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task PostTodoListAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="TodoListService.PutTodoListAsync(TodoListResponse)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task PutTodoListAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="TodoListService.DeleteTodoListAsync(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteTodoListAsync()
        {
            await Task.CompletedTask;
        }
    }
}

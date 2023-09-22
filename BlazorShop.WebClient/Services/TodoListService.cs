// <copyright file="TodoListService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Services
{
    /// <summary>
    /// An implementation of <see cref="ITodoListService"/>.
    /// </summary>
    public partial class TodoListService : ITodoListService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TodoListService"/> class.
        /// </summary>
        /// <param name="httpClient">The instance of the <see cref="HttpClient"/> to use.</param>
        /// <param name="snackBar">The instance of the <see cref="ISnackbar"/> to use.</param>
        public TodoListService(HttpClient httpClient, ISnackbar snackBar)
        {
            this.HttpClient = httpClient;
            this.Options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            this.SnackBar = snackBar;
        }

        /// <summary>
        /// Gets the instance of the <see cref="HttpClient"/> to use.
        /// </summary>
        private HttpClient HttpClient { get; }

        /// <summary>
        /// Gets the instance of the <see cref="ISnackbar"/> to use.
        /// </summary>
        private ISnackbar SnackBar { get; }

        /// <summary>
        /// Gets the instance of the <see cref="JsonSerializerOptions"/> to use.
        /// </summary>
        private JsonSerializerOptions Options { get; }

        /// <inheritdoc/>
        public async Task<List<TodoListResponse>> GetTodoListsAsync()
        {
            var response = await Policy<HttpResponseMessage>
                .Handle<Exception>()
                .WaitAndRetryAsync(2, _ => TimeSpan.FromSeconds(1))
                .ExecuteAsync(async () => await this.HttpClient.GetAsync("TodoLists/lists"));

            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<TodoListResponse>>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
                return null;
            }

            return !response.IsSuccessStatusCode
                ? null
                : result.Items;
        }

        /// <inheritdoc/>
        public async Task<TodoListResponse> GetTodoListAsync(int id)
        {
            var response = await Policy<HttpResponseMessage>
                .Handle<Exception>()
                .WaitAndRetryAsync(2, _ => TimeSpan.FromSeconds(1))
                .ExecuteAsync(async () => await this.HttpClient.GetAsync($"TodoLists/list/{id}"));

            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<TodoListResponse>>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }

            return !response.IsSuccessStatusCode
                ? null
                : result.Item;
        }

        /// <inheritdoc/>
        public async Task<TodoListResponse> PostTodoListAsync(TodoListResponse todoList)
        {
            var response = await Policy<HttpResponseMessage>
                .Handle<Exception>()
                .WaitAndRetryAsync(2, _ => TimeSpan.FromSeconds(1))
                .ExecuteAsync(async () => await this.HttpClient.PostAsJsonAsync($"TodoLists/list", todoList));

            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<TodoListResponse>>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                this.SnackBar.Add("The todo list was created.", Severity.Success);
            }

            return !response.IsSuccessStatusCode
                ? null
                : result.Item;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> PutTodoListAsync(TodoListResponse todoList)
        {
            var response = await Policy<HttpResponseMessage>
                .Handle<Exception>()
                .WaitAndRetryAsync(2, _ => TimeSpan.FromSeconds(1))
                .ExecuteAsync(async () => await this.HttpClient.PutAsJsonAsync("TodoLists/list", todoList));

            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                this.SnackBar.Add("The todo list was updated.", Severity.Success);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> DeleteTodoListAsync(int id)
        {
            var response = await Policy<HttpResponseMessage>
                .Handle<Exception>()
                .WaitAndRetryAsync(2, _ => TimeSpan.FromSeconds(1))
                .ExecuteAsync(async () => await this.HttpClient.DeleteAsync($"TodoLists/list/{id}"));

            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                this.SnackBar.Add("The todo list was deleted.", Severity.Success);
            }

            return result;
        }
    }
}

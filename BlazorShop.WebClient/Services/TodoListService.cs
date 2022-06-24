// <copyright file="TodoListService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Services
{
    public partial class TodoListService : ITodoListService
    {
        private readonly HttpClient _httpClient;
        private readonly ISnackbar _snackBar;
        private readonly JsonSerializerOptions _options;

        public TodoListService(HttpClient httpClient, ISnackbar snackBar)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _snackBar = snackBar;
        }

        /// <inheritdoc/>
        public async Task<List<TodoListResponse>> GetTodoListsAsync()
        {
            var response = await _httpClient.GetAsync("TodoLists/lists");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<TodoListResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
                return null;
            }

            return result.Items;
        }

        /// <inheritdoc/>
        public async Task<TodoListResponse> GetTodoListAsync(int id)
        {
            var response = await _httpClient.GetAsync($"TodoLists/list/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<TodoListResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
                return null;
            }

            return result.Item;
        }

        /// <inheritdoc/>
        public async Task<TodoListResponse> PostTodoListAsync(TodoListResponse todoList)
        {
            var response = await _httpClient.PostAsJsonAsync($"TodoLists/list", todoList);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<TodoListResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
                return null;
            }

            _snackBar.Add("The todo list was created.", Severity.Success);
            return result.Item;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> PutTodoListAsync(TodoListResponse todoList)
        {
            var response = await _httpClient.PutAsJsonAsync("TodoLists/list", todoList);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
                return result;
            }

            _snackBar.Add("The todo list was updated.", Severity.Success);
            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> DeleteTodoListAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"TodoLists/list/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
                return result;
            }

            _snackBar.Add("The todo list was deleted.", Severity.Success);
            return result;
        }
    }
}

// <copyright file="TodoItemService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Services
{
    /// <summary>
    /// An implementation of <see cref="ITodoItemService"/>.
    /// </summary>
    public class TodoItemService : ITodoItemService
    {
        private readonly HttpClient _httpClient;
        private readonly ISnackbar _snackBar;
        private readonly JsonSerializerOptions _options;

        public TodoItemService(HttpClient httpClient, ISnackbar snackBar)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _snackBar = snackBar;
        }

        /// <inheritdoc/>
        public async Task<TodoItemResponse> GetTodoItemAsync(int id)
        {
            var response = await _httpClient.GetAsync($"TodoItems/item/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<TodoItemResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
            }

            return !response.IsSuccessStatusCode
                ? null
                : result.Item;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> PutTodoItemAsync(TodoItemResponse todoItem)
        {
            var response = await _httpClient.PutAsJsonAsync("TodoItems/item", todoItem);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                _snackBar.Add("The todo item was updated.", Severity.Success);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> DeleteTodoItemAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"TodoItems/item/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                _snackBar.Add("The todo item was deleted.", Severity.Success);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<TodoItemResponse> PostTodoItemAsync(TodoItemResponse todoItem)
        {
            var response = await _httpClient.PostAsJsonAsync("TodoItems/item", todoItem);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<TodoItemResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                _snackBar.Add("The todo item was added.", Severity.Success);
            }

            return !response.IsSuccessStatusCode
                ? null
                : result.Item;
        }
    }
}

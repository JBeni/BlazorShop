namespace BlazorShop.WebClient.Services
{
    public partial class TodoListService : ITodoListService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;

        public TodoListService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
        }

        public async Task<List<TodoListResponse>> GetTodoListsAsync()
        {
            var response = await _httpClient.GetAsync("TodoLists/lists");
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<Result<TodoListResponse>>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                _toastService.ShowError(resultError.Error);
                return null;
            }

            var result = JsonSerializer.Deserialize<Result<TodoListResponse>>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result.Items;
        }

        public async Task<TodoListResponse> GetTodoListAsync(int id)
        {
            var response = await _httpClient.GetAsync($"TodoLists/list/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<Result<TodoListResponse>>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                _toastService.ShowError(resultError.Error);
                return null;
            }

            var result = JsonSerializer.Deserialize<Result<TodoListResponse>>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result.Item;
        }

        public async Task<TodoListResponse> PostTodoListAsync(TodoListResponse todoList)
        {
            var response = await _httpClient.PostAsJsonAsync($"TodoLists/list", todoList);
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<Result<TodoListResponse>>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                _toastService.ShowError(resultError.Error);
                return null;
            }

            var result = JsonSerializer.Deserialize<Result<TodoListResponse>>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            _toastService.ShowSuccess("The todo list was created.");
            return result.Item;
        }

        public async Task<RequestResponse> PutTodoListAsync(TodoListResponse todoList)
        {
            var response = await _httpClient.PutAsJsonAsync("TodoLists/list", todoList);
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<RequestResponse>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                _toastService.ShowError(resultError.Error);
                return RequestResponse.Failure(resultError.Error);
            }

            _toastService.ShowSuccess("The todo list was updated.");
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteTodoListAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"TodoLists/list/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<RequestResponse>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                _toastService.ShowError(resultError.Error);
                return RequestResponse.Failure(resultError.Error);
            }

            _toastService.ShowSuccess("The todo list was deleted.");
            return RequestResponse.Success();
        }
    }
}

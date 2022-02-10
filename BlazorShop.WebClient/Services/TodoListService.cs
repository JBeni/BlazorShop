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
            var result = JsonSerializer.Deserialize<Result<TodoListResponse>>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            return result.Items;
        }

        public async Task<TodoListResponse> GetTodoListAsync(int id)
        {
            var response = await _httpClient.GetAsync($"TodoLists/list/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<TodoListResponse>>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            return result.Item;
        }

        public async Task<TodoListResponse> PostTodoListAsync(TodoListResponse todoList)
        {
            var response = await _httpClient.PostAsJsonAsync($"TodoLists/list", todoList);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<TodoListResponse>>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            _toastService.ShowSuccess("The todo list was created.");
            return result.Item;
        }

        public async Task<RequestResponse> PutTodoListAsync(TodoListResponse todoList)
        {
            var response = await _httpClient.PutAsJsonAsync("TodoLists/list", todoList);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The todo list was updated.");
            return result;
        }

        public async Task<RequestResponse> DeleteTodoListAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"TodoLists/list/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The todo list was deleted.");
            return result;
        }
    }
}

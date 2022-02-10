namespace BlazorShop.WebClient.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;

        public TodoItemService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
        }

        public async Task<TodoItemResponse> GetTodoItemAsync(int id)
        {
            var response = await _httpClient.GetAsync($"TodoItems/item/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<TodoItemResponse>>(
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

        public async Task<RequestResponse> PutTodoItemAsync(TodoItemResponse todoItem)
        {
            var response = await _httpClient.PutAsJsonAsync("TodoItems/item", todoItem);
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

            _toastService.ShowSuccess("The todo item was updated.");
            return result;
        }

        public async Task<RequestResponse> DeleteTodoItemAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"TodoItems/item/{id}");
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

            _toastService.ShowSuccess("The todo item was deleted.");
            return result;
        }

        public async Task<TodoItemResponse> PostTodoItemAsync(TodoItemResponse todoItem)
        {
            var response = await _httpClient.PostAsJsonAsync("TodoItems/item", todoItem);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<TodoItemResponse>>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            _toastService.ShowSuccess("The todo item was added.");
            return result.Item;
        }
    }
}

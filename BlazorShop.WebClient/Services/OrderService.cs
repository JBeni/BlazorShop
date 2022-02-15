namespace BlazorShop.WebClient.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;
        private readonly JsonSerializerOptions _options;

        public OrderService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<OrderResponse>> GetOrders(string userEmail)
        {
            var response = await _httpClient.GetAsync($"Orders/orders/{userEmail}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<OrderResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            return result.Items;
        }

        public async Task<OrderResponse> GetOrder(int id, string userEmail)
        {
            var response = await _httpClient.GetAsync($"Orders/order/{id}/{userEmail}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<OrderResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            return result.Item;
        }

        public async Task<RequestResponse> AddOrder(OrderResponse order)
        {
            var response = await _httpClient.PostAsJsonAsync("Orders/order", order);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The Order was added.");
            return result;
        }

        public async Task<RequestResponse> UpdateOrder(OrderResponse order)
        {
            var response = await _httpClient.PutAsJsonAsync("Orders/order", order);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The Order was updated.");
            return result;
        }

        public async Task<RequestResponse> DeleteOrder(int id)
        {
            var response = await _httpClient.DeleteAsync($"Orders/order/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The Order was deleted.");
            return result;
        }
    }
}

namespace BlazorShop.WebClient.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;

        public OrderService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
        }

        public async Task<List<OrderResponse>> GetOrders(string userEmail)
        {
            var authResult = await _httpClient.GetAsync($"Orders/orders/{userEmail}");
            if (authResult.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<OrderResponse>>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task<OrderResponse> GetOrder(int id, string userEmail)
        {
            var authResult = await _httpClient.GetAsync($"Orders/order/{id}/{userEmail}");
            if (authResult.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<OrderResponse>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task<RequestResponse> AddOrder(OrderResponse order)
        {
            var response = await _httpClient.PostAsJsonAsync("Orders/order", order);
            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            _toastService.ShowSuccess("The Order was added.");
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> UpdateOrder(OrderResponse order)
        {
            var response = await _httpClient.PutAsJsonAsync("Orders/order", order);
            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            _toastService.ShowSuccess("The Order was updated.");
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteOrder(int id)
        {
            var response = await _httpClient.DeleteAsync($"Orders/order/{id}");
            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            _toastService.ShowSuccess("The Order was deleted.");
            return RequestResponse.Success();
        }
    }
}

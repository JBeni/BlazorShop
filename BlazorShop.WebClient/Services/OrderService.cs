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
            var response = await _httpClient.GetAsync($"Orders/orders/{userEmail}");
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<ErrorView>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                _toastService.ShowError(resultError.Title + ": " + resultError.Detail);
                return null;
            }

            var result = JsonSerializer.Deserialize<List<OrderResponse>>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task<OrderResponse> GetOrder(int id, string userEmail)
        {
            var response = await _httpClient.GetAsync($"Orders/order/{id}/{userEmail}");
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<ErrorView>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                _toastService.ShowError(resultError.Title + ": " + resultError.Detail);
                return null;
            }

            var result = JsonSerializer.Deserialize<OrderResponse>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task<RequestResponse> AddOrder(OrderResponse order)
        {
            var response = await _httpClient.PostAsJsonAsync("Orders/order", order);
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<ErrorView>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                _toastService.ShowError(resultError.Title + ": " + resultError.Detail);
                return null;
            }

            _toastService.ShowSuccess("The Order was added.");
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> UpdateOrder(OrderResponse order)
        {
            var response = await _httpClient.PutAsJsonAsync("Orders/order", order);
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<ErrorView>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                _toastService.ShowError(resultError.Title + ": " + resultError.Detail);
                return null;
            }

            _toastService.ShowSuccess("The Order was updated.");
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteOrder(int id)
        {
            var response = await _httpClient.DeleteAsync($"Orders/order/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<ErrorView>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                _toastService.ShowError(resultError.Title + ": " + resultError.Detail);
                return null;
            }

            _toastService.ShowSuccess("The Order was deleted.");
            return RequestResponse.Success();
        }
    }
}

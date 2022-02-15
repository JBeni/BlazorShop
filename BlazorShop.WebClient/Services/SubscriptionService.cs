namespace BlazorShop.WebClient.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;
        private readonly JsonSerializerOptions _options;

        public SubscriptionService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<SubscriptionResponse>> GetSubscriptions()
        {
            var response = await _httpClient.GetAsync("Subscriptions/subscriptions");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<SubscriptionResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            return result.Items;
        }

        public async Task<SubscriptionResponse> GetSubscription(int id)
        {
            var response = await _httpClient.GetAsync($"Subscriptions/subscription/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<SubscriptionResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            return result.Item;
        }

        public async Task<RequestResponse> AddSubscription(SubscriptionResponse Subscription)
        {
            var response = await _httpClient.PostAsJsonAsync("Subscriptions/subscription", Subscription);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The Subscription was added.");
            return result;
        }

        public async Task<RequestResponse> UpdateSubscription(SubscriptionResponse Subscription)
        {
            var response = await _httpClient.PutAsJsonAsync("Subscriptions/subscription", Subscription);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The Subscription was updated.");
            return result;
        }

        public async Task<RequestResponse> DeleteSubscription(int id)
        {
            var response = await _httpClient.DeleteAsync($"Subscriptions/subscription/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The Subscription was deleted.");
            return result;
        }
    }
}

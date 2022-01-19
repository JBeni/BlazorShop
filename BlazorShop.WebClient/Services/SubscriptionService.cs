namespace BlazorShop.WebClient.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;

        public SubscriptionService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
        }

        public async Task<List<SubscriptionResponse>> GetSubscriptions()
        {
            var authResult = await _httpClient.GetAsync("Subscriptions/subscriptions");
            if (authResult.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<SubscriptionResponse>>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task<SubscriptionResponse> GetSubscription(int id)
        {
            var authResult = await _httpClient.GetAsync($"Subscriptions/subscription/{id}");
            if (authResult.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<SubscriptionResponse>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task<RequestResponse> AddSubscription(SubscriptionResponse Subscription)
        {
            var response = await _httpClient.PostAsJsonAsync("Subscriptions/subscription", Subscription);
            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            _toastService.ShowSuccess("The Subscription was added.");
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> UpdateSubscription(SubscriptionResponse Subscription)
        {
            var response = await _httpClient.PutAsJsonAsync("Subscriptions/subscription", Subscription);
            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            _toastService.ShowSuccess("The Subscription was updated.");
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteSubscription(int id)
        {
            var response = await _httpClient.DeleteAsync($"Subscriptions/subscription/{id}");
            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            _toastService.ShowSuccess("The Subscription was deleted.");
            return RequestResponse.Success();
        }
    }
}

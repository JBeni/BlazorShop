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
            var response = await _httpClient.GetAsync("Subscriptions/subscriptions");
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

            var result = JsonSerializer.Deserialize<List<SubscriptionResponse>>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task<SubscriptionResponse> GetSubscription(int id)
        {
            var response = await _httpClient.GetAsync($"Subscriptions/subscription/{id}");
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

            var result = JsonSerializer.Deserialize<SubscriptionResponse>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task<RequestResponse> AddSubscription(SubscriptionResponse Subscription)
        {
            var response = await _httpClient.PostAsJsonAsync("Subscriptions/subscription", Subscription);
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

            _toastService.ShowSuccess("The Subscription was added.");
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> UpdateSubscription(SubscriptionResponse Subscription)
        {
            var response = await _httpClient.PutAsJsonAsync("Subscriptions/subscription", Subscription);
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

            _toastService.ShowSuccess("The Subscription was updated.");
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteSubscription(int id)
        {
            var response = await _httpClient.DeleteAsync($"Subscriptions/subscription/{id}");
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

            _toastService.ShowSuccess("The Subscription was deleted.");
            return RequestResponse.Success();
        }
    }
}

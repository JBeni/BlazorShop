namespace BlazorShop.WebClient.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly HttpClient _httpClient;
        private readonly ISnackbar _snackBar;
        private readonly JsonSerializerOptions _options;

        public SubscriptionService(HttpClient httpClient, ISnackbar snackBar)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _snackBar = snackBar;
        }

        /// <inheritdoc/>
        public async Task<List<SubscriptionResponse>> GetSubscriptions()
        {
            var response = await _httpClient.GetAsync("Subscriptions/subscriptions");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<SubscriptionResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
                return null;
            }

            return result.Items;
        }

        /// <inheritdoc/>
        public async Task<SubscriptionResponse> GetSubscription(int id)
        {
            var response = await _httpClient.GetAsync($"Subscriptions/subscription/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<SubscriptionResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
                return null;
            }

            return result.Item;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> AddSubscription(SubscriptionResponse Subscription)
        {
            var response = await _httpClient.PostAsJsonAsync("Subscriptions/subscription", Subscription);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
                return result;
            }

            _snackBar.Add("The Subscription was added.", Severity.Success);
            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> UpdateSubscription(SubscriptionResponse Subscription)
        {
            var response = await _httpClient.PutAsJsonAsync("Subscriptions/subscription", Subscription);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
                return result;
            }

            _snackBar.Add("The Subscription was updated.", Severity.Success);
            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> DeleteSubscription(int id)
        {
            var response = await _httpClient.DeleteAsync($"Subscriptions/subscription/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
                return result;
            }

            _snackBar.Add("The Subscription was deleted.", Severity.Success);
            return result;
        }
    }
}

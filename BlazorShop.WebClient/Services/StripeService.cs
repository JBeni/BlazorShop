using MudBlazor;

namespace BlazorShop.WebClient.Services
{
    public class StripeService : IStripeService
    {
        private readonly HttpClient _httpClient;
        private readonly ISnackbar _snackBar;
        private readonly JsonSerializerOptions _options;

        public StripeService(HttpClient httpClient, ISnackbar snackBar)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _snackBar = snackBar;
        }

        /// <inheritdoc/>
        public async Task CancelMembership(string stripeSubscriptionCreationId)
        {
            var response = await _httpClient.DeleteAsync($"Payments/cancel-subscription/{stripeSubscriptionCreationId}");
            if (response.IsSuccessStatusCode == false)
            {
                var responseResult = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<RequestResponse>(
                    responseResult, _options
                );

                _snackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                _snackBar.Add("Subscription was cancelled.", Severity.Success);
            }
        }
    }
}

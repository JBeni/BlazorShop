namespace BlazorShop.WebClient.Services
{
    public class StripeService : IStripeService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;

        public StripeService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
        }

        public async Task CancelMembership(string stripeSubscriptionCreationId)
        {
            var response = await _httpClient.DeleteAsync($"Payments/cancel-subscription/{stripeSubscriptionCreationId}");
            if (response.IsSuccessStatusCode == false)
            {
                var responseResult = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<RequestResponse>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                _toastService.ShowError(result.Error);
            }
            else
            {
                _toastService.ShowSuccess("Subscription was cancelled.");
            }
        }
    }
}

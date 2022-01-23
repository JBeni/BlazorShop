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
            var authResult = await _httpClient.DeleteAsync($"Payments/cancel-subscription/{stripeSubscriptionCreationId}");
            if (authResult.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
            }
            else
            {
                _toastService.ShowSuccess("Subscription was cancelled.");
            }
        }
    }
}

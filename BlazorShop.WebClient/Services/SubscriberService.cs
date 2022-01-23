namespace BlazorShop.WebClient.Services
{
    public class SubscriberService : ISubscriberService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;

        public SubscriberService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
        }

        public async Task<List<SubscriberResponse>> GetSubscribers()
        {
            var authResult = await _httpClient.GetAsync("Subscribers/subscribers");
            if (authResult.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<SubscriberResponse>>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task<List<SubscriberResponse>> GetUserAllSubscribers(int userId)
        {
            var authResult = await _httpClient.GetAsync($"Subscribers/subscribers/{userId}");
            if (authResult.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<SubscriberResponse>>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task<SubscriberResponse> GetUserSubscriber(int userId)
        {
            var authResult = await _httpClient.GetAsync($"Subscribers/subscriber/{userId}");
            if (authResult.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<SubscriberResponse>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task<RequestResponse> AddSubscriber(SubscriberResponse Subscriber)
        {
            var response = await _httpClient.PostAsJsonAsync("Subscribers/subscriber", Subscriber);
            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            _toastService.ShowSuccess("The Subscriber was added.");
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> UpdateSubscriber(SubscriberResponse Subscriber)
        {
            var response = await _httpClient.PutAsJsonAsync("Subscribers/subscriber", Subscriber);
            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            _toastService.ShowSuccess("The Subscriber was updated.");
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteSubscriber(int id)
        {
            var response = await _httpClient.DeleteAsync($"Subscribers/subscriber/{id}");
            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            _toastService.ShowSuccess("The Subscriber was deleted.");
            return RequestResponse.Success();
        }
    }
}

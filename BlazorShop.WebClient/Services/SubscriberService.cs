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
            var response = await _httpClient.GetAsync("Subscribers/subscribers");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<SubscriberResponse>>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            return result.Items;
        }

        public async Task<List<SubscriberResponse>> GetUserAllSubscribers(int userId)
        {
            var response = await _httpClient.GetAsync($"Subscribers/subscribers/{userId}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<SubscriberResponse>>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            return result.Items;
        }

        public async Task<SubscriberResponse> GetUserSubscriber(int userId)
        {
            var response = await _httpClient.GetAsync($"Subscribers/subscriber/{userId}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<SubscriberResponse>>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            return result.Item;
        }

        public async Task<RequestResponse> AddSubscriber(SubscriberResponse Subscriber)
        {
            var response = await _httpClient.PostAsJsonAsync("Subscribers/subscriber", Subscriber);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The Subscriber was added.");
            return result;
        }

        public async Task<RequestResponse> UpdateSubscriber(SubscriberResponse Subscriber)
        {
            var response = await _httpClient.PutAsJsonAsync("Subscribers/subscriber", Subscriber);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The Subscriber was updated.");
            return result;
        }

        public async Task<RequestResponse> DeleteSubscriber(int id)
        {
            var response = await _httpClient.DeleteAsync($"Subscribers/subscriber/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The Subscriber was deleted.");
            return result;
        }
    }
}

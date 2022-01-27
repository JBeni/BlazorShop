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
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<ErrorView>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                _toastService.ShowError(resultError.Title + ": " + resultError.Detail);
                return null;
            }

            var result = JsonSerializer.Deserialize<List<SubscriberResponse>>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task<List<SubscriberResponse>> GetUserAllSubscribers(int userId)
        {
            var response = await _httpClient.GetAsync($"Subscribers/subscribers/{userId}");
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

            var result = JsonSerializer.Deserialize<List<SubscriberResponse>>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task<SubscriberResponse> GetUserSubscriber(int userId)
        {
            var response = await _httpClient.GetAsync($"Subscribers/subscriber/{userId}");
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

            var result = JsonSerializer.Deserialize<SubscriberResponse>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task<RequestResponse> AddSubscriber(SubscriberResponse Subscriber)
        {
            var response = await _httpClient.PostAsJsonAsync("Subscribers/subscriber", Subscriber);
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

            _toastService.ShowSuccess("The Subscriber was added.");
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> UpdateSubscriber(SubscriberResponse Subscriber)
        {
            var response = await _httpClient.PutAsJsonAsync("Subscribers/subscriber", Subscriber);
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

            _toastService.ShowSuccess("The Subscriber was updated.");
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteSubscriber(int id)
        {
            var response = await _httpClient.DeleteAsync($"Subscribers/subscriber/{id}");
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

            _toastService.ShowSuccess("The Subscriber was deleted.");
            return RequestResponse.Success();
        }
    }
}

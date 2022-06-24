// <copyright file="SubscriberService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Services
{
    public class SubscriberService : ISubscriberService
    {
        private readonly HttpClient _httpClient;
        private readonly ISnackbar _snackBar;
        private readonly JsonSerializerOptions _options;

        public SubscriberService(HttpClient httpClient, ISnackbar snackBar)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _snackBar = snackBar;
        }

        /// <inheritdoc/>
        public async Task<List<SubscriberResponse>> GetSubscribers()
        {
            var response = await _httpClient.GetAsync("Subscribers/subscribers");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<SubscriberResponse>>(
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
        public async Task<List<SubscriberResponse>> GetUserAllSubscribers(int userId)
        {
            var response = await _httpClient.GetAsync($"Subscribers/subscribers/{userId}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<SubscriberResponse>>(
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
        public async Task<SubscriberResponse> GetUserSubscriber(int userId)
        {
            var response = await _httpClient.GetAsync($"Subscribers/subscriber/{userId}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<SubscriberResponse>>(
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
        public async Task<RequestResponse> AddSubscriber(SubscriberResponse Subscriber)
        {
            var response = await _httpClient.PostAsJsonAsync("Subscribers/subscriber", Subscriber);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
                return result;
            }

            _snackBar.Add("The Subscriber was added.", Severity.Success);
            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> UpdateSubscriber(SubscriberResponse Subscriber)
        {
            var response = await _httpClient.PutAsJsonAsync("Subscribers/subscriber", Subscriber);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
                return result;
            }

            _snackBar.Add("The Subscriber was updated.", Severity.Success);
            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> DeleteSubscriber(int id)
        {
            var response = await _httpClient.DeleteAsync($"Subscribers/subscriber/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
                return result;
            }

            _snackBar.Add("The Subscriber was deleted.", Severity.Success);
            return result;
        }
    }
}

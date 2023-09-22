// <copyright file="SubscriberService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Services
{
    /// <summary>
    /// An implementation of <see cref="ISubscriberService"/>.
    /// </summary>
    public class SubscriberService : ISubscriberService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriberService"/> class.
        /// </summary>
        /// <param name="httpClient">The instance of the <see cref="HttpClient"/> to use.</param>
        /// <param name="snackBar">The instance of the <see cref="ISnackbar"/> to use.</param>
        public SubscriberService(HttpClient httpClient, ISnackbar snackBar)
        {
            this.HttpClient = httpClient;
            this.Options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            this.SnackBar = snackBar;
        }

        /// <summary>
        /// Gets the instance of the <see cref="HttpClient"/> to use.
        /// </summary>
        private HttpClient HttpClient { get; }

        /// <summary>
        /// Gets the instance of the <see cref="ISnackbar"/> to use.
        /// </summary>
        private ISnackbar SnackBar { get; }

        /// <summary>
        /// Gets the instance of the <see cref="JsonSerializerOptions"/> to use.
        /// </summary>
        private JsonSerializerOptions Options { get; }

        /// <inheritdoc/>
        public async Task<List<SubscriberResponse>> GetSubscribers()
        {
            var response = await Policy<HttpResponseMessage>
                .Handle<Exception>()
                .WaitAndRetryAsync(2, _ => TimeSpan.FromSeconds(1))
                .ExecuteAsync(async () => await this.HttpClient.GetAsync("Subscribers/subscribers"));

            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<SubscriberResponse>>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }

            return !response.IsSuccessStatusCode
                ? null
                : result.Items;
        }

        /// <inheritdoc/>
        public async Task<List<SubscriberResponse>> GetUserAllSubscribers(int userId)
        {
            var response = await Policy<HttpResponseMessage>
                .Handle<Exception>()
                .WaitAndRetryAsync(2, _ => TimeSpan.FromSeconds(1))
                .ExecuteAsync(async () => await this.HttpClient.GetAsync($"Subscribers/subscribers/{userId}"));

            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<SubscriberResponse>>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }

            return !response.IsSuccessStatusCode
                ? null
                : result.Items;
        }

        /// <inheritdoc/>
        public async Task<SubscriberResponse> GetUserSubscriber(int userId)
        {
            var response = await Policy<HttpResponseMessage>
                .Handle<Exception>()
                .WaitAndRetryAsync(2, _ => TimeSpan.FromSeconds(1))
                .ExecuteAsync(async () => await this.HttpClient.GetAsync($"Subscribers/subscriber/{userId}"));

            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<SubscriberResponse>>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }

            return !response.IsSuccessStatusCode
                ? null
                : result.Item;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> AddSubscriber(SubscriberResponse subscriber)
        {
            var response = await Policy<HttpResponseMessage>
                .Handle<Exception>()
                .WaitAndRetryAsync(2, _ => TimeSpan.FromSeconds(1))
                .ExecuteAsync(async () => await this.HttpClient.PostAsJsonAsync("Subscribers/subscriber", subscriber));

            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                this.SnackBar.Add("The Subscriber was added.", Severity.Success);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> UpdateSubscriber(SubscriberResponse subscriber)
        {
            var response = await Policy<HttpResponseMessage>
                .Handle<Exception>()
                .WaitAndRetryAsync(2, _ => TimeSpan.FromSeconds(1))
                .ExecuteAsync(async () => await this.HttpClient.PutAsJsonAsync("Subscribers/subscriber", subscriber));

            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                this.SnackBar.Add("The Subscriber was updated.", Severity.Success);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> DeleteSubscriber(int id)
        {
            var response = await Policy<HttpResponseMessage>
                .Handle<Exception>()
                .WaitAndRetryAsync(2, _ => TimeSpan.FromSeconds(1))
                .ExecuteAsync(async () => await this.HttpClient.DeleteAsync($"Subscribers/subscriber/{id}"));

            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                this.SnackBar.Add("The Subscriber was deleted.", Severity.Success);
            }

            return result;
        }
    }
}

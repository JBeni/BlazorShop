// <copyright file="SubscriptionService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Services
{
    /// <summary>
    /// An implementation of <see cref="ISubscriptionService"/>.
    /// </summary>
    public class SubscriptionService : ISubscriptionService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionService"/> class.
        /// </summary>
        /// <param name="httpClient">The instance of the <see cref="System.Net.Http.HttpClient"/> to use.</param>
        /// <param name="snackBar">The instance of the <see cref="ISnackbar"/> to use.</param>
        public SubscriptionService(HttpClient httpClient, ISnackbar snackBar)
        {
            this.HttpClient = httpClient;
            this.Options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            this.SnackBar = snackBar;
        }

        /// <summary>
        /// Gets the instance of the <see cref="System.Net.Http.HttpClient"/> to use.
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
        public async Task<List<SubscriptionResponse>> GetSubscriptions()
        {
            var response = await this.HttpClient.GetAsync("Subscriptions/subscriptions");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<SubscriptionResponse>>(
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
        public async Task<SubscriptionResponse> GetSubscription(int id)
        {
            var response = await this.HttpClient.GetAsync($"Subscriptions/subscription/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<SubscriptionResponse>>(
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
        public async Task<RequestResponse> AddSubscription(SubscriptionResponse subscription)
        {
            var response = await this.HttpClient.PostAsJsonAsync("Subscriptions/subscription", subscription);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                this.SnackBar.Add("The Subscription was added.", Severity.Success);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> UpdateSubscription(SubscriptionResponse subscription)
        {
            var response = await this.HttpClient.PutAsJsonAsync("Subscriptions/subscription", subscription);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                this.SnackBar.Add("The Subscription was updated.", Severity.Success);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> DeleteSubscription(int id)
        {
            var response = await this.HttpClient.DeleteAsync($"Subscriptions/subscription/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                this.SnackBar.Add("The Subscription was deleted.", Severity.Success);
            }

            return result;
        }
    }
}

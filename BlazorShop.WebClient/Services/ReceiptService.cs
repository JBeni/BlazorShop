// <copyright file="ReceiptService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using MudBlazor;

namespace BlazorShop.WebClient.Services
{
    /// <summary>
    /// An implementation of <see cref="IReceiptService"/>.
    /// </summary>
    public class ReceiptService : IReceiptService
    {
        /// <summary>
        /// .
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// .
        /// </summary>
        private readonly ISnackbar _snackBar;

        /// <summary>
        /// .
        /// </summary>
        private readonly JsonSerializerOptions _options;

        /// <summary>
        /// .
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="snackBar"></param>
        public ReceiptService(HttpClient httpClient, ISnackbar snackBar)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _snackBar = snackBar;
        }

        /// <inheritdoc/>
        public async Task<List<ReceiptResponse>> GetReceipts(string userEmail)
        {
            var response = await _httpClient.GetAsync($"Receipts/receipts/{userEmail}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<ReceiptResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
            }

            return !response.IsSuccessStatusCode
                ? null
                : result.Items;
        }

        /// <inheritdoc/>
        public async Task<ReceiptResponse> GetReceipt(int id, string userEmail)
        {
            var response = await _httpClient.GetAsync($"Receipts/receipt/{id}/{userEmail}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<ReceiptResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
            }

            return !response.IsSuccessStatusCode
                ? null
                : result.Item;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> AddReceipt(ReceiptResponse receipt)
        {
            var response = await _httpClient.PostAsJsonAsync("Receipts/receipt", receipt);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                _snackBar.Add("The Receipt was added.", Severity.Success);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> UpdateReceipt(ReceiptResponse receipt)
        {
            var response = await _httpClient.PutAsJsonAsync("Receipts/receipt", receipt);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                _snackBar.Add("The Receipt was updated.", Severity.Success);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> DeleteReceipt(int id)
        {
            var response = await _httpClient.DeleteAsync($"Receipts/receipt/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                _snackBar.Add("The Receipt was deleted.", Severity.Success);
            }

            return result;
        }
    }
}

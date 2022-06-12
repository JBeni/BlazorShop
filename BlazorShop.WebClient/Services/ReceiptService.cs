using MudBlazor;

namespace BlazorShop.WebClient.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly HttpClient _httpClient;
        private readonly ISnackbar _snackBar;
        private readonly JsonSerializerOptions _options;

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
                return null;
            }

            return result.Items;
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
                return null;
            }

            return result.Item;
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
                return result;
            }

            _snackBar.Add("The Receipt was added.", Severity.Success);
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
                return result;
            }

            _snackBar.Add("The Receipt was updated.", Severity.Success);
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
                return result;
            }

            _snackBar.Add("The Receipt was deleted.", Severity.Success);
            return result;
        }
    }
}

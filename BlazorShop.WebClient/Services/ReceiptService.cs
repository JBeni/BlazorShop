namespace BlazorShop.WebClient.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;

        public ReceiptService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
        }

        public async Task<List<ReceiptResponse>> GetReceipts(string userEmail)
        {
            var response = await _httpClient.GetAsync($"Receipts/receipts/{userEmail}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<ReceiptResponse>>(
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

        public async Task<ReceiptResponse> GetReceipt(int id, string userEmail)
        {
            var response = await _httpClient.GetAsync($"Receipts/receipt/{id}/{userEmail}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<ReceiptResponse>>(
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

        public async Task<RequestResponse> AddReceipt(ReceiptResponse receipt)
        {
            var response = await _httpClient.PostAsJsonAsync("Receipts/receipt", receipt);
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

            _toastService.ShowSuccess("The Receipt was added.");
            return result;
        }

        public async Task<RequestResponse> UpdateReceipt(ReceiptResponse receipt)
        {
            var response = await _httpClient.PutAsJsonAsync("Receipts/receipt", receipt);
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

            _toastService.ShowSuccess("The Receipt was updated.");
            return result;
        }

        public async Task<RequestResponse> DeleteReceipt(int id)
        {
            var response = await _httpClient.DeleteAsync($"Receipts/receipt/{id}");
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

            _toastService.ShowSuccess("The Receipt was deleted.");
            return result;
        }
    }
}

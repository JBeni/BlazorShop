namespace BlazorShop.WebClient.Services
{
    public class ClotheService : IClotheService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;

        public event Action OnChange;

        public ClotheService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
        }

        public async Task<List<ClotheResponse>> GetClothes()
        {
            var response = await _httpClient.GetAsync("Clothes/clothes");
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<Result<ClotheResponse>>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                _toastService.ShowError(resultError.Error);
                return null;
            }

            var result = JsonSerializer.Deserialize<Result<ClotheResponse>>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result.Items;
        }

        public async Task<ClotheResponse> GetClothe(int id)
        {
            var response = await _httpClient.GetAsync($"Clothes/clothe/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<Result<ClotheResponse>>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                _toastService.ShowError(resultError.Error);
                return null;
            }

            var result = JsonSerializer.Deserialize<Result<ClotheResponse>>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result.Item;
        }

        public async Task<RequestResponse> AddClothe(ClotheResponse clothe)
        {
            var response = await _httpClient.PostAsJsonAsync("Clothes/clothe", clothe);
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<RequestResponse>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                _toastService.ShowError(resultError.Error);
                return RequestResponse.Failure(resultError.Error);
            }

            _toastService.ShowSuccess("The clothe was added.");
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> UpdateClothe(ClotheResponse clothe)
        {
            var response = await _httpClient.PutAsJsonAsync("Clothes/clothe", clothe);
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<RequestResponse>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                _toastService.ShowError(resultError.Error);
                return RequestResponse.Failure(resultError.Error);
            }

            _toastService.ShowSuccess("The clothe was updated.");
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteClothe(int id)
        {
            var response = await _httpClient.DeleteAsync($"Clothes/clothe/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<RequestResponse>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                _toastService.ShowError(resultError.Error);
                return RequestResponse.Failure(resultError.Error);
            }

            _toastService.ShowSuccess("The clothe was deleted.");
            return RequestResponse.Success();
        }
    }
}

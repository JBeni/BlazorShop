namespace BlazorShop.WebClient.Services
{
    public class ClotheService : IClotheService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;
        private readonly JsonSerializerOptions _options;

        public ClotheService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<ClotheResponse>> GetClothes()
        {
            var response = await _httpClient.GetAsync("Clothes/clothes");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<ClotheResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            return result.Items;
        }

        public async Task<ClotheResponse> GetClothe(int id)
        {
            var response = await _httpClient.GetAsync($"Clothes/clothe/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<ClotheResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            return result.Item;
        }

        public async Task<RequestResponse> AddClothe(ClotheResponse clothe)
        {
            var response = await _httpClient.PostAsJsonAsync("Clothes/clothe", clothe);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The clothe was added.");
            return result;
        }

        public async Task<RequestResponse> UpdateClothe(ClotheResponse clothe)
        {
            var response = await _httpClient.PutAsJsonAsync("Clothes/clothe", clothe);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The clothe was updated.");
            return result;
        }

        public async Task<RequestResponse> DeleteClothe(int id)
        {
            var response = await _httpClient.DeleteAsync($"Clothes/clothe/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The clothe was deleted.");
            return result;
        }
    }
}

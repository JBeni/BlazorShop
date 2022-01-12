namespace BlazorShop.WebClient.Services
{
    public class ClotheService : IClotheService
    {
        private readonly HttpClient _httpClient;

        public ClotheService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ClotheResponse>> GetClothes()
        {
            var authResult = await _httpClient.GetAsync("Clothes/clothes");

            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<ClotheResponse>>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task<ClotheResponse> GetClothe(int id)
        {
            var authResult = await _httpClient.GetAsync($"Clothes/clothe/{id}");
            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ClotheResponse>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task AddClothe(ClotheResponse clothe)
        {
            await _httpClient.PostAsJsonAsync("Clothes/clothe", clothe);
        }

        public async Task UpdateClothe(ClotheResponse clothe)
        {
            await _httpClient.PutAsJsonAsync("Clothes/clothe", clothe);
        }

        public async Task DeleteClothe(int id)
        {
            await _httpClient.DeleteAsync($"Clothes/clothe/{id}");
        }
    }
}

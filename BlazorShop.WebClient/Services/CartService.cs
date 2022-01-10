namespace BlazorShop.WebClient.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _httpClient;

        public CartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddCart(CartResponse cart)
        {
            await _httpClient.PostAsJsonAsync($"Carts/cart", cart);
        }

        public async Task DeleteCart(int id)
        {
            await _httpClient.GetAsync($"Carts/cart/{id}");
        }

        public async Task<CartResponse> GetCart(int id)
        {
            var authResult = await _httpClient.GetAsync($"Carts/cart/{id}");
            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<CartResponse>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task<int> GetCartCounts()
        {
            var authResult = await _httpClient.GetAsync("Carts/count");
            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<int>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task<List<CartResponse>> GetCarts()
        {
            var authResult = await _httpClient.GetAsync("Carts/carts");
            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<CartResponse>>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task UpdateCart(CartResponse cart)
        {
            await _httpClient.PutAsJsonAsync($"Carts/cart", cart);
        }
    }
}

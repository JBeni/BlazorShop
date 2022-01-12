namespace BlazorShop.WebClient.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;

        public event Action OnChange;

        public CartService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
        }

        public async Task AddCart(CartResponse cart)
        {
            var response = await _httpClient.PostAsJsonAsync($"Carts/cart", cart);

            if (!response.IsSuccessStatusCode) _toastService.ShowError("Something went wrong.");
            _toastService.ShowSuccess(cart.Name, "The item was added to cart:");

            OnChange.Invoke();
        }

        public async Task DeleteCart(int id)
        {
            var response = await _httpClient.DeleteAsync($"Carts/cart/{id}");

            if (!response.IsSuccessStatusCode) _toastService.ShowError("Something went wrong.");
            _toastService.ShowSuccess("The item was deleted from the cart.");
        }

        public async Task EmptyCart()
        {
            var response = await _httpClient.DeleteAsync($"Carts/carts");

            if (!response.IsSuccessStatusCode) _toastService.ShowError("Something went wrong.");
            _toastService.ShowSuccess("The items from the cart were removed.");

            OnChange.Invoke();
        }

        public async Task<CartResponse> GetCart(int id)
        {
            var authResult = await _httpClient.GetAsync($"Carts/cart/{id}");
            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<CartResponse>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
            if (!authResult.IsSuccessStatusCode) _toastService.ShowError("Something went wrong.");

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
            if (!authResult.IsSuccessStatusCode) _toastService.ShowError("Something went wrong.");

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
            if (!authResult.IsSuccessStatusCode) _toastService.ShowError("Something went wrong.");

            return result;
        }

        public async Task UpdateCart(CartResponse cart)
        {
            var response = await _httpClient.PutAsJsonAsync($"Carts/cart", cart);

            if (!response.IsSuccessStatusCode) _toastService.ShowError("Something went wrong.");
            _toastService.ShowSuccess("The cart was updated.");

            OnChange.Invoke();
        }

        public async Task<string> Checkout()
        {
            var result = await _httpClient.PostAsJsonAsync("Payments/checkout", await GetCarts());
            var url = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode) _toastService.ShowError("Something went wrong.");
            _toastService.ShowSuccess("The checkout operation was successfully made.");

            return url;
        }
    }
}

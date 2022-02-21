namespace BlazorShop.WebClient.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;
        private readonly JsonSerializerOptions _options;

        public CartService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<RequestResponse> AddCart(CartResponse cart)
        {
            var response = await _httpClient.PostAsJsonAsync($"Carts/cart", cart);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess(cart.Name, "The item was added to cart:");
            return result;
        }

        public async Task<RequestResponse> DeleteCart(int id, int userId)
        {
            var response = await _httpClient.DeleteAsync($"Carts/cart/{id}/{userId}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The item was deleted from the cart.");
            return result;
        }

        public async Task<RequestResponse> EmptyCart(int userId)
        {
            var response = await _httpClient.DeleteAsync($"Carts/carts/{userId}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The items from the cart were removed.");
            return result;
        }

        public async Task<CartResponse> GetCart(int id, int userId)
        {
            var response = await _httpClient.GetAsync($"Carts/cart/{id}/{userId}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<CartResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            return result.Item;
        }

        public async Task<int> GetCartCounts(int userId)
        {
            var response = await _httpClient.GetAsync($"Carts/count/{userId}");
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<RequestResponse>(
                    responseResult, _options
                );

                _toastService.ShowError(resultError.Error);
                return 0;
            }

            var result = JsonSerializer.Deserialize<int>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task<List<CartResponse>> GetCarts(int userId)
        {
            var response = await _httpClient.GetAsync($"Carts/carts/{userId}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<CartResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            return result.Items;
        }

        public async Task<RequestResponse> UpdateCart(CartResponse cart)
        {
            var response = await _httpClient.PutAsJsonAsync($"Carts/cart", cart);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The cart was updated.");
            return result;
        }

        public async Task<string> Checkout(int userId)
        {
            var carts = await GetCarts(userId);
            var response = await _httpClient.PostAsJsonAsync("Payments/checkout", carts.ToList());
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            _toastService.ShowSuccess("The checkout operation was successfully made.");
            return responseResult;
        }
    }
}

// <copyright file="CartService.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Services
{
    /// <summary>
    /// An implementation of <see cref="ICartService"/>.
    /// </summary>
    public class CartService : ICartService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CartService"/> class.
        /// </summary>
        /// <param name="httpClient">The instance of the <see cref="HttpClient"/> to use.</param>
        /// <param name="snackBar">The instance of the <see cref="ISnackbar"/> to use.</param>
        public CartService(HttpClient httpClient, ISnackbar snackBar)
        {
            this.HttpClient = httpClient;
            this.Options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            this.SnackBar = snackBar;
        }

        /// <summary>
        /// Gets the instance of the <see cref="HttpClient"/> to use.
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
        public async Task<RequestResponse> AddCart(CartResponse cart)
        {
            var response = await this.HttpClient.PostAsJsonAsync($"Carts/cart", cart);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                this.SnackBar.Add($"The item was added to cart: {cart.Name}", Severity.Success);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> DeleteCart(int id, int userId)
        {
            var response = await this.HttpClient.DeleteAsync($"Carts/cart/{id}/{userId}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                this.SnackBar.Add("The item was deleted from the cart.", Severity.Success);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> EmptyCart(int userId)
        {
            var response = await this.HttpClient.DeleteAsync($"Carts/carts/{userId}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                this.SnackBar.Add("The items from the cart were removed.", Severity.Success);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<CartResponse> GetCart(int id, int userId)
        {
            var response = await this.HttpClient.GetAsync($"Carts/cart/{id}/{userId}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<CartResponse>>(
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
        public async Task<int> GetCartCounts(int userId)
        {
            var response = await this.HttpClient.GetAsync($"Carts/count/{userId}");
            var responseResult = await response.Content.ReadAsStringAsync();

            var result = 0;
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<RequestResponse>(
                    responseResult, this.Options);

                this.SnackBar.Add(resultError.Error, Severity.Error);
            }
            else
            {
                result = JsonSerializer.Deserialize<int>(
                    responseResult, this.Options);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<List<CartResponse>> GetCarts(int userId)
        {
            var response = await this.HttpClient.GetAsync($"Carts/carts/{userId}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<CartResponse>>(
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
        public async Task<RequestResponse> UpdateCart(CartResponse cart)
        {
            var response = await this.HttpClient.PutAsJsonAsync($"Carts/cart", cart);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                this.SnackBar.Add("The cart was updated.", Severity.Success);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<string> Checkout(int userId)
        {
            var carts = await this.GetCarts(userId);
            var response = await this.HttpClient.PostAsJsonAsync("Payments/checkout", carts.ToList());
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                this.SnackBar.Add("The checkout operation was successfully made.", Severity.Success);
            }

            return !response.IsSuccessStatusCode
                ? null
                : responseResult;
        }
    }
}

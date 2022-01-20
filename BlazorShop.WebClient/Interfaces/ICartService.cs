namespace BlazorShop.WebClient.Interfaces
{
    public interface ICartService
    {
        event Action OnChange;

        Task<List<CartResponse>> GetCarts();
        Task<int> GetCartCounts();
        Task<CartResponse> GetCart(int id);
        Task<RequestResponse> AddCart(CartResponse cart);
        Task<RequestResponse> UpdateCart(CartResponse cart);
        Task<RequestResponse> DeleteCart(int id);

        Task<RequestResponse> EmptyCart();
        Task<string> Checkout();
    }
}

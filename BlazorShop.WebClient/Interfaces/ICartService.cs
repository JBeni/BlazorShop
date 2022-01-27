namespace BlazorShop.WebClient.Interfaces
{
    public interface ICartService
    {
        event Action OnChange;

        Task<List<CartResponse>> GetCarts(int userId);
        Task<int> GetCartCounts(int userId);
        Task<CartResponse> GetCart(int id, int userId);
        Task<RequestResponse> AddCart(CartResponse cart);
        Task<RequestResponse> UpdateCart(CartResponse cart);
        Task<RequestResponse> DeleteCart(int id, int userId);

        Task<RequestResponse> EmptyCart(int userId);
        Task<string> Checkout(int userId);
    }
}

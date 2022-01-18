namespace BlazorShop.WebClient.Interfaces
{
    public interface ICartService
    {
        event Action OnChange;

        Task<List<CartResponse>> GetCarts();
        Task<int> GetCartCounts();
        Task<CartResponse> GetCart(int id);
        Task<RequestResponse> AddCart(CartResponse Cart);
        Task<RequestResponse> UpdateCart(CartResponse Cart);
        Task<RequestResponse> DeleteCart(int id);

        Task<RequestResponse> EmptyCart();
        Task<string> Checkout();
    }
}

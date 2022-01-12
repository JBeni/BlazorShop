namespace BlazorShop.WebClient.Interfaces
{
    public interface ICartService
    {
        event Action OnChange;

        Task<List<CartResponse>> GetCarts();
        Task<int> GetCartCounts();
        Task<CartResponse> GetCart(int id);
        Task AddCart(CartResponse Cart);
        Task UpdateCart(CartResponse Cart);
        Task DeleteCart(int id);

        Task EmptyCart();
        Task<string> Checkout();
    }
}

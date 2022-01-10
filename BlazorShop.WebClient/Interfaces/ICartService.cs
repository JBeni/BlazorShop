namespace BlazorShop.WebClient.Interfaces
{
    public interface ICartService
    {
        Task<List<CartResponse>> GetCarts();
        Task<int> GetCartCounts();
        Task<CartResponse> GetCart(int id);
        Task AddCart(CartResponse Cart);
        Task UpdateCart(CartResponse Cart);
        Task DeleteCart(int id);
    }
}

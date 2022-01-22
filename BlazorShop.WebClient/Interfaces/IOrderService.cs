namespace BlazorShop.WebClient.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderResponse>> GetOrders(string userEmail);
        Task<OrderResponse> GetOrder(int id, string userEmail);
        Task<RequestResponse> AddOrder(OrderResponse Order);
        Task<RequestResponse> UpdateOrder(OrderResponse Order);
        Task<RequestResponse> DeleteOrder(int id);
    }
}

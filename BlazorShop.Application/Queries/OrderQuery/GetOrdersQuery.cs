namespace BlazorShop.Application.Queries.OrderQuery
{
    public class GetOrdersQuery : IRequest<List<OrderResponse>>
    {
        public string UserEmail { get; set; }
    }
}

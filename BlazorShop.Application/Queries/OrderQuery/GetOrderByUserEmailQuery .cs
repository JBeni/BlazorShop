namespace BlazorShop.Application.Queries.OrderQuery
{
    public class GetOrderByUserEmailQuery : IRequest<OrderResponse>
    {
        public string UserEmail { get; set; }
    }
}

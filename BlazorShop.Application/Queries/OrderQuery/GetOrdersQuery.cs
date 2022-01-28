namespace BlazorShop.Application.Queries.OrderQuery
{
    public class GetOrdersQuery : IRequest<Result<OrderResponse>>
    {
        public string UserEmail { get; set; }
    }
}

namespace BlazorShop.Application.Queries.OrderQuery
{
    public class GetOrderByIdQuery : IRequest<OrderResponse>
    {
        public int Id { get; set; }
    }
}

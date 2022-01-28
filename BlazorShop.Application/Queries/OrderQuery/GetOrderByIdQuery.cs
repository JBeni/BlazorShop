namespace BlazorShop.Application.Queries.OrderQuery
{
    public class GetOrderByIdQuery : IRequest<Result<OrderResponse>>
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
    }
}

namespace BlazorShop.Application.Queries.OrderQuery
{
    public class GetOrdersQuery : IRequest<Result<OrderResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public string UserEmail { get; set; }
    }
}

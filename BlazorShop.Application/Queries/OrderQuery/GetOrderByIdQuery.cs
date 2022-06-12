namespace BlazorShop.Application.Queries.OrderQuery
{
    public class GetOrderByIdQuery : IRequest<Result<OrderResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string UserEmail { get; set; }
    }
}

namespace BlazorShop.Application.Queries.SubscriptionQuery
{
    public class GetSubscriptionByIdQuery : IRequest<Result<SubscriptionResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}

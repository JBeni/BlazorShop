namespace BlazorShop.Application.Queries.SubscriptionQuery
{
    public class GetSubscriptionByIdQuery : IRequest<Result<SubscriptionResponse>>
    {
        public int Id { get; set; }
    }
}

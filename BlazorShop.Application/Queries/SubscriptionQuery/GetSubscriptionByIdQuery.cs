namespace BlazorShop.Application.Queries.SubscriptionQuery
{
    public class GetSubscriptionByIdQuery : IRequest<SubscriptionResponse>
    {
        public int Id { get; set; }
    }
}

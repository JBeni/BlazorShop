namespace BlazorShop.Application.Queries.SubscriberQuery
{
    public class GetUserSubscribersQuery : IRequest<List<SubscriberResponse>>
    {
        public int UserId { get; set; }
    }
}

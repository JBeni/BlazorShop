namespace BlazorShop.Application.Queries.SubscriberQuery
{
    public class GetUserSubscribersQuery : IRequest<Result<SubscriberResponse>>
    {
        public int UserId { get; set; }
    }
}

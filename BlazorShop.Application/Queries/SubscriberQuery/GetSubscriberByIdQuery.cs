namespace BlazorShop.Application.Queries.SubscriberQuery
{
    public class GetSubscriberByIdQuery : IRequest<Result<SubscriberResponse>>
    {
        public int UserId { get; set; }
    }
}

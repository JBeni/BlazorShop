namespace BlazorShop.Application.Queries.SubscriberQuery
{
    public class GetSubscriberByIdQuery : IRequest<SubscriberResponse>
    {
        public int Id { get; set; }
    }
}

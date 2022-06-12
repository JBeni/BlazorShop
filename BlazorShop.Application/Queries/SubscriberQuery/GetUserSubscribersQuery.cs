namespace BlazorShop.Application.Queries.SubscriberQuery
{
    public class GetUserSubscribersQuery : IRequest<Result<SubscriberResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int UserId { get; set; }
    }
}

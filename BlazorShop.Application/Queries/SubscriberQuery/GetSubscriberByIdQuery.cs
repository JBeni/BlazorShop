namespace BlazorShop.Application.Queries.SubscriberQuery
{
    public class GetSubscriberByIdQuery : IRequest<Result<SubscriberResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int UserId { get; set; }
    }
}

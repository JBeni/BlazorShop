namespace BlazorShop.Application.Commands.SubscriberCommand
{
    public class UpdateSubscriberStatusCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public string StripeSubscriberSubscriptionId { get; set; }
    }
}

namespace BlazorShop.Application.Commands.SubscriberCommand
{
    public class UpdateSubscriberStatusCommand : IRequest<RequestResponse>
    {
        public string StripeSubscriberSubscriptionId { get; set; }
    }
}

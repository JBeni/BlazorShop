namespace BlazorShop.Application.Commands.SubscriberCommand
{
    public class UpdateCreatedSubscriberCommand : IRequest<RequestResponse>
    {
        public SubscriptionStatus Status { get; set; }
        public DateTime CurrentPeriodEnd { get; set; }
        public DateTime CurrentPeriodStart { get; set; }
        public string CustomerEmail { get; set; }
        public string StripeSubscriberSubscriptionId { get; set; }
        public string HostedInvoiceUrl { get; set; }
    }
}

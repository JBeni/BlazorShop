namespace BlazorShop.Application.Commands.SubscriberCommand
{
    public class UpdateSubscriberCommand : IRequest<RequestResponse>
    {
		public int Id { get; set; }
		public DateTime DateStart { get; set; }
		public DateTime CurrentPeriodEnd { get; set; }
		public int CustomerId { get; set; }
		public int SubscriptionId { get; set; }
		public string StripeSubscriptionId { get; set; }
		public string StripeSubscriberSubscriptionId { get; set; }
	}
}

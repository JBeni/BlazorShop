namespace BlazorShop.Application.Commands.SubscriberCommand
{
    public class UpdateSubscriberStatusCommand : IRequest<RequestResponse>
    {
		public int Id { get; set; }
		public SubscriptionStatus Status { get; set; }
	}
}

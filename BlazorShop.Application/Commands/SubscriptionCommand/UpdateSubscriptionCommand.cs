namespace BlazorShop.Application.Commands.SubscriptionCommand
{
    public class UpdateSubscriptionCommand : IRequest<RequestResponse>
    {
		public int Id { get; set; }
		public string StripeSubscriptionId { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public string Options { get; set; }
	}
}

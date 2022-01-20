namespace BlazorShop.Application.Commands.SubscriptionCommand
{
    public class CreateSubscriptionCommand : IRequest<RequestResponse>
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string Currency { get; set; }
		public string CurrencySymbol { get; set; }
		public string ChargeType { get; set; }
		public string Options { get; set; }
	}
}

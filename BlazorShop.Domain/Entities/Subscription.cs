namespace BlazorShop.Domain.Entities
{
    public class Subscription : EntityBase
    {
		public string StripeSubscriptionId { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public string Currency { get; set; }
		public string CurrencySymbol { get; set; }
		public string ChargeType { get; set; }
		public string Options { get; set; }
		public string ImageName { get; set; }
		public string ImagePath { get; set; }
	}
}

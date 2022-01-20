namespace BlazorShop.Domain.Entities
{
    public class Subscription : EntityBase
    {
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string Currency { get; set; }
		public string CurrencySymbol { get; set; }
		public string ChargeType { get; set; }
		public string Options { get; set; }
	}
}

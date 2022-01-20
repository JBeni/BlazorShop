namespace BlazorShop.Domain.Entities
{
    public class Subscriber : EntityBase
    {
		public SubscriptionStatus Status { get; set; }
		public DateTime DateStart { get; set; }
		public DateTime CurrentPeriodEnd { get; set; }

		public User Customer { get; set; }
		public Subscription Subscription { get; set; }
	}
}

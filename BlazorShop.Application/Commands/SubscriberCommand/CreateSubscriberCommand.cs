namespace BlazorShop.Application.Commands.SubscriberCommand
{
    public class CreateSubscriberCommand : IRequest<RequestResponse>
    {
		/// <summary>
		/// .
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// .
		/// </summary>
		public DateTime DateStart { get; set; }

		/// <summary>
		/// .
		/// </summary>
		public DateTime CurrentPeriodEnd { get; set; }

		/// <summary>
		/// .
		/// </summary>
		public int CustomerId { get; set; }

		/// <summary>
		/// .
		/// </summary>
		public int SubscriptionId { get; set; }

		/// <summary>
		/// .
		/// </summary>
		public string StripeSubscriptionId { get; set; }
	}
}

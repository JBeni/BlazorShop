// <copyright file="CreateSubscriberCommand.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.SubscriberCommand
{
	/// <summary>
	/// A model to create a subscriber.
	/// </summary>
	public class CreateSubscriberCommand : IRequest<RequestResponse>
    {
		/// <summary>
		/// The id of the subscriber.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// The started date of the subscriber.
		/// </summary>
		public DateTime DateStart { get; set; }

		/// <summary>
		/// The date when the current period ends.
		/// </summary>
		public DateTime CurrentPeriodEnd { get; set; }

		/// <summary>
		/// The customer id.
		/// </summary>
		public int CustomerId { get; set; }

		/// <summary>
		/// The subscription id.
		/// </summary>
		public int SubscriptionId { get; set; }

		/// <summary>
		/// The id of the stripe subscription.
		/// </summary>
		public string StripeSubscriptionId { get; set; }
	}
}

// <copyright file="Subscriber.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Entities
{
	/// <summary>
	/// A template for the entity subscriber.
	/// </summary>
	public class Subscriber : EntityBase
    {
		/// <summary>
		/// .
		/// </summary>
		public SubscriptionStatus Status { get; set; }

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
		public DateTime CurrentPeriodStart { get; set; }

		/// <summary>
		/// .
		/// </summary>
		public string StripeSubscriberSubscriptionId { get; set; }

		/// <summary>
		/// .
		/// </summary>
		public string HostedInvoiceUrl { get; set; }

		/// <summary>
		/// .
		/// </summary>
		public User Customer { get; set; }

		/// <summary>
		/// .
		/// </summary>
		public Subscription Subscription { get; set; }
	}
}

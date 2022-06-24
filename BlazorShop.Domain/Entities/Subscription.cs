// <copyright file="Subscription.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Entities
{
    public class Subscription : EntityBase
    {
		/// <summary>
		/// .
		/// </summary>
		public string StripeSubscriptionId { get; set; }

		/// <summary>
		/// .
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// .
		/// </summary>
		public int Price { get; set; }

		/// <summary>
		/// .
		/// </summary>
		public string Currency { get; set; }

		/// <summary>
		/// .
		/// </summary>
		public string CurrencySymbol { get; set; }

		/// <summary>
		/// .
		/// </summary>
		public string ChargeType { get; set; }

		/// <summary>
		/// .
		/// </summary>
		public string Options { get; set; }

		/// <summary>
		/// .
		/// </summary>
		public string ImageName { get; set; }

		/// <summary>
		/// .
		/// </summary>
		public string ImagePath { get; set; }
	}
}

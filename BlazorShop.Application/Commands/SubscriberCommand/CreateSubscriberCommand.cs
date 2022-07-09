// <copyright file="CreateSubscriberCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.SubscriberCommand
{
	/// <summary>
	/// A model to update a cart.
	/// </summary>
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

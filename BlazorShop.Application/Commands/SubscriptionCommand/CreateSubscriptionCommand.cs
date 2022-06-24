// <copyright file="CreateSubscriptionCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.SubscriptionCommand
{
	/// <summary>
	/// A model to update a cart.
	/// </summary>
	public class CreateSubscriptionCommand : IRequest<RequestResponse>
    {
		/// <summary>
		/// .
		/// </summary>
		public int Id { get; set; }

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

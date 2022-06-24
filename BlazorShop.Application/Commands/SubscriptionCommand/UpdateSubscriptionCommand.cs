// <copyright file="UpdateSubscriptionCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.SubscriptionCommand
{
    public class UpdateSubscriptionCommand : IRequest<RequestResponse>
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

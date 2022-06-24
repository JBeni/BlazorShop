// <copyright file="DeleteSubscriptionCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.SubscriptionCommand
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class DeleteSubscriptionCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
		public int Id { get; set; }
	}
}

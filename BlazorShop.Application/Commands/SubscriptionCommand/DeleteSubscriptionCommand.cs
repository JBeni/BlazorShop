// <copyright file="DeleteSubscriptionCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.SubscriptionCommand
{
    public class DeleteSubscriptionCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
		public int Id { get; set; }
	}
}

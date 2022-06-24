// <copyright file="DeleteSubscriberCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.SubscriberCommand
{
    public class DeleteSubscriberCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
		public int Id { get; set; }
	}
}

// <copyright file="DeleteSubscriptionCommand.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.SubscriptionCommand
{
    /// <summary>
    /// A model to delete a subscription.
    /// </summary>
    public class DeleteSubscriptionCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The id of the subscription.
        /// </summary>
        public int Id { get; set; }
    }
}

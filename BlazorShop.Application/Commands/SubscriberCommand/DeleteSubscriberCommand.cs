// <copyright file="DeleteSubscriberCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.SubscriberCommand
{
    /// <summary>
    /// A model to delete a subscriber.
    /// </summary>
    public class DeleteSubscriberCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or Sets The id of the subscriber.
        /// </summary>
        public int Id { get; set; }
    }
}

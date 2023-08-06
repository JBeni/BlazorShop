// <copyright file="DeleteOrderCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.OrderCommand
{
    /// <summary>
    /// A model to delete an order.
    /// </summary>
    public class DeleteOrderCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The id of the order.
        /// </summary>
        public int Id { get; set; }
    }
}

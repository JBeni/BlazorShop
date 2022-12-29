// <copyright file="DeleteOrderCommand.cs" author="Beniamin Jitca">
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
        /// The id of the order.
        /// </summary>
        public int Id { get; set; }
    }
}

// <copyright file="DeleteOrderCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.OrderCommand
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class DeleteOrderCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}

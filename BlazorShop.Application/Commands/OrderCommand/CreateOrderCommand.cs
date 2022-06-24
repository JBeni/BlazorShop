// <copyright file="CreateOrderCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.OrderCommand
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class CreateOrderCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string LineItems { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public int AmountTotal { get; set; }
    }
}

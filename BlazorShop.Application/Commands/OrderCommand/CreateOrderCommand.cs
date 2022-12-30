// <copyright file="CreateOrderCommand.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.OrderCommand
{
    /// <summary>
    /// A model to create an order.
    /// </summary>
    public class CreateOrderCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The email of the user.
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or sets The date when the order was placed.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets The items placed in the current order.
        /// </summary>
        public string LineItems { get; set; }

        /// <summary>
        /// Gets or sets The total amount of the items from the order.
        /// </summary>
        public int AmountTotal { get; set; }
    }
}

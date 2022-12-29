// <copyright file="CreateOrderCommand.cs" author="Beniamin Jitca">
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
        /// The email of the user.
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// The date when the order was placed.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// The items placed in the current order.
        /// </summary>
        public string LineItems { get; set; }

        /// <summary>
        /// The total amount of the items from the order.
        /// </summary>
        public int AmountTotal { get; set; }
    }
}

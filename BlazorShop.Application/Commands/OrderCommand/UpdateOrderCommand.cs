// <copyright file="UpdateOrderCommand.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.OrderCommand
{
    /// <summary>
    /// A model to update an order.
    /// </summary>
    public class UpdateOrderCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// The id of the order.
        /// </summary>
        public int Id { get; set; }

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

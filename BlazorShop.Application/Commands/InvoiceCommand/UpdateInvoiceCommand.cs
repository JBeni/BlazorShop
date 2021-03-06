// <copyright file="UpdateInvoiceCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.InvoiceCommand
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class UpdateInvoiceCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public int AmountSubTotal { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public int AmountTotal { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public int Quantity { get; set; }
    }
}

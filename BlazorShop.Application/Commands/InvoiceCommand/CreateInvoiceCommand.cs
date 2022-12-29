// <copyright file="CreateInvoiceCommand.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.InvoiceCommand
{
    /// <summary>
    /// A model to create an invoice.
    /// </summary>
    public class CreateInvoiceCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// The email of the user.
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// The name of the invoice.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The sub total amount of the invoice.
        /// </summary>
        public int AmountSubTotal { get; set; }

        /// <summary>
        /// The total amount of the invoice.
        /// </summary>
        public int AmountTotal { get; set; }

        /// <summary>
        /// The quantity of the invoice.
        /// </summary>
        public int Quantity { get; set; }
    }
}

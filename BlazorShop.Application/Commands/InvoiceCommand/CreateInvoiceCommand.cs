// <copyright file="CreateInvoiceCommand.cs" company="Beniamin Jitca" author="Beniamin Jitca">
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
        /// Gets or sets The email of the user.
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or sets The name of the invoice.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets The sub total amount of the invoice.
        /// </summary>
        public int AmountSubTotal { get; set; }

        /// <summary>
        /// Gets or sets The total amount of the invoice.
        /// </summary>
        public int AmountTotal { get; set; }

        /// <summary>
        /// Gets or sets The quantity of the invoice.
        /// </summary>
        public int Quantity { get; set; }
    }
}

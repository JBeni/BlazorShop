// <copyright file="UpdateInvoiceCommand.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.InvoiceCommand
{
    /// <summary>
    /// A model to update an invoice.
    /// </summary>
    public class UpdateInvoiceCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The id of the invoice.
        /// </summary>
        public int Id { get; set; }

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

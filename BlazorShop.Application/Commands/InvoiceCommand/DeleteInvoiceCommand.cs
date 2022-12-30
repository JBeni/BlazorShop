// <copyright file="DeleteInvoiceCommand.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.InvoiceCommand
{
    /// <summary>
    /// A model to delete an invoice.
    /// </summary>
    public class DeleteInvoiceCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The id of the invoice.
        /// </summary>
        public int Id { get; set; }
    }
}

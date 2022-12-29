// <copyright file="DeleteInvoiceCommand.cs" author="Beniamin Jitca">
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
        /// The id of the invoice.
        /// </summary>
        public int Id { get; set; }
    }
}

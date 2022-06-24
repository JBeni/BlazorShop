// <copyright file="DeleteInvoiceCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.InvoiceCommand
{
    public class DeleteInvoiceCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}

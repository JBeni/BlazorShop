// <copyright file="GetInvoiceByIdQuery.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.InvoiceQuery
{
    /// <summary>
    /// A model to get the invoice.
    /// </summary>
    public class GetInvoiceByIdQuery : IRequest<Result<InvoiceResponse>>
    {
        /// <summary>
        /// The id of the invoice.
        /// </summary>
        public int Id { get; set; }
    }
}

// <copyright file="GetInvoiceByIdQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.InvoiceQuery
{
    public class GetInvoiceByIdQuery : IRequest<Result<InvoiceResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}

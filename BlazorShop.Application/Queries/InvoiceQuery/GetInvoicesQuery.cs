// <copyright file="GetInvoicesQuery.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.InvoiceQuery
{
    /// <summary>
    /// A model to get the invoices.
    /// </summary>
    public class GetInvoicesQuery : IRequest<Result<InvoiceResponse>>
    {
    }
}

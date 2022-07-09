// <copyright file="GetReceiptsQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.ReceiptQuery
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetReceiptsQuery : IRequest<Result<ReceiptResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public string UserEmail { get; set; }
    }
}

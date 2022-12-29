// <copyright file="GetReceiptsQuery.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.ReceiptQuery
{
    /// <summary>
    /// A model to get the receipts.
    /// </summary>
    public class GetReceiptsQuery : IRequest<Result<ReceiptResponse>>
    {
        /// <summary>
        /// The email of the user.
        /// </summary>
        public string UserEmail { get; set; }
    }
}

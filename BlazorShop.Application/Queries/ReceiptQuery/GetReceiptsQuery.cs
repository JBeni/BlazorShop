// <copyright file="GetReceiptsQuery.cs" company="Beniamin Jitca" author="Beniamin Jitca">
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
        /// Gets or sets The email of the user.
        /// </summary>
        public string UserEmail { get; set; }
    }
}

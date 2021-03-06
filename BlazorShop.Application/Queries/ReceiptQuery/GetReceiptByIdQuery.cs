// <copyright file="GetReceiptByIdQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.ReceiptQuery
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetReceiptByIdQuery : IRequest<Result<ReceiptResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string UserEmail { get; set; }
    }
}

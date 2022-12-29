// <copyright file="GetReceiptByIdQuery.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.ReceiptQuery
{
    /// <summary>
    /// A model to get the receipt.
    /// </summary>
    public class GetReceiptByIdQuery : IRequest<Result<ReceiptResponse>>
    {
        /// <summary>
        /// The id of the receipt.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The email of the user.
        /// </summary>
        public string UserEmail { get; set; }
    }
}

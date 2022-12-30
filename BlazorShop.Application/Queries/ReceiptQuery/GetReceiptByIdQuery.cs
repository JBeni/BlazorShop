// <copyright file="GetReceiptByIdQuery.cs" company="Beniamin Jitca" author="Beniamin Jitca">
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
        /// Gets or sets The id of the receipt.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets The email of the user.
        /// </summary>
        public string UserEmail { get; set; }
    }
}

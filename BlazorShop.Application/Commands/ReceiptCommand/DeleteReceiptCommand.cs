// <copyright file="DeleteReceiptCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.ReceiptCommand
{
    /// <summary>
    /// A model to delete a receipt.
    /// </summary>
    public class DeleteReceiptCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The id of the receipt.
        /// </summary>
        public int Id { get; set; }
    }
}

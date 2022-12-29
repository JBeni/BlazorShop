// <copyright file="DeleteReceiptCommand.cs" author="Beniamin Jitca">
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
        /// The id of the receipt.
        /// </summary>
        public int Id { get; set; }
    }
}

// <copyright file="UpdateReceiptCommand.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.ReceiptCommand
{
    /// <summary>
    /// A model to update a receipt.
    /// </summary>
    public class UpdateReceiptCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// The id of the receipt.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The email of the user.
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// The date when the receipt was generated.
        /// </summary>
        public DateTime ReceiptDate { get; set; }

        /// <summary>
        /// The name of the receipt.
        /// </summary>
        public string ReceiptName { get; set; }

        /// <summary>
        /// The url of the receipt.
        /// </summary>
        public string ReceiptUrl { get; set; }
    }
}

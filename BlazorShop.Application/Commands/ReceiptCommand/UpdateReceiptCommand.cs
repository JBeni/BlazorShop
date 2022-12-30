// <copyright file="UpdateReceiptCommand.cs" company="Beniamin Jitca" author="Beniamin Jitca">
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
        /// Gets or sets The id of the receipt.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets The email of the user.
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or sets The date when the receipt was generated.
        /// </summary>
        public DateTime ReceiptDate { get; set; }

        /// <summary>
        /// Gets or sets The name of the receipt.
        /// </summary>
        public string ReceiptName { get; set; }

        /// <summary>
        /// Gets or sets The url of the receipt.
        /// </summary>
        public string ReceiptUrl { get; set; }
    }
}

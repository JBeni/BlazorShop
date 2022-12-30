// <copyright file="CreateReceiptCommand.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.ReceiptCommand
{
    /// <summary>
    /// A model to create a receipt.
    /// </summary>
    public class CreateReceiptCommand : IRequest<RequestResponse>
    {
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

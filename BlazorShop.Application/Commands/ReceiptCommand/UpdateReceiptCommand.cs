// <copyright file="UpdateReceiptCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.ReceiptCommand
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class UpdateReceiptCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public DateTime ReceiptDate { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string ReceiptName { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string ReceiptUrl { get; set; }
    }
}

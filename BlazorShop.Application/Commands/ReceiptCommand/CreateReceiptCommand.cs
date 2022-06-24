// <copyright file="CreateReceiptCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.ReceiptCommand
{
    public class CreateReceiptCommand : IRequest<RequestResponse>
    {
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

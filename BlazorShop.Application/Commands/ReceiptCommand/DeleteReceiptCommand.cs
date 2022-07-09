// <copyright file="DeleteReceiptCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.ReceiptCommand
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class DeleteReceiptCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}

// <copyright file="DeleteCartCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.CartCommand
{
    /// <summary>
    /// A model to delete a cart.
    /// </summary>
    public class DeleteCartCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The id of the cart.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets The id of the user.
        /// </summary>
        public int UserId { get; set; }
    }
}

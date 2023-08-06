// <copyright file="CreateCartCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.CartCommand
{
    /// <summary>
    /// A model to create a cart.
    /// </summary>
    public class CreateCartCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The id of the user.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets The id of the clothe.
        /// </summary>
        public int ClotheId { get; set; }

        /// <summary>
        /// Gets or sets The name of the cart.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets The price of the cart.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets The amount of the cart.
        /// </summary>
        public int Amount { get; set; }
    }
}

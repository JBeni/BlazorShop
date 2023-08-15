﻿// <copyright file="Cart.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Entities
{
    /// <summary>
    /// A template for the entity cart.
    /// </summary>
    public class Cart : EntityBase
    {
        /// <summary>
        /// Gets or sets the name of the cart.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the price of the cart.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the amount of the cart.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets the clothe.
        /// </summary>
        public Clothe? Clothe { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public User? User { get; set; }
    }
}

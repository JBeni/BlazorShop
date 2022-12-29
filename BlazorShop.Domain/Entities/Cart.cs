// <copyright file="Cart.cs" author="Beniamin Jitca">
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
        /// .
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public Clothe? Clothe { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public User? User { get; set; }
    }
}

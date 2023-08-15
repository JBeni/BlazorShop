// <copyright file="Invoice.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Entities
{
    /// <summary>
    /// A template for the entity invoice.
    /// </summary>
    public class Invoice : EntityBase
    {
        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or sets the name of the invoice.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the sub total amount of the invoice.
        /// </summary>
        public int AmountSubTotal { get; set; }

        /// <summary>
        /// Gets or sets the total amount of the invoice.
        /// </summary>
        public int AmountTotal { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the invoice.
        /// </summary>
        public int Quantity { get; set; }
    }
}

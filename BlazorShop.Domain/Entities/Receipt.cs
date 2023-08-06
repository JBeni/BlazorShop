// <copyright file="Receipt.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Entities
{
    /// <summary>
    /// A template for the entity receipt.
    /// </summary>
    public class Receipt : EntityBase
    {
        /// <summary>
        /// Gets or Sets the email of the user.
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or Sets the date of the receipt.
        /// </summary>
        public DateTime ReceiptDate { get; set; }

        /// <summary>
        /// Gets or Sets the name of the receipt.
        /// </summary>
        public string ReceiptName { get; set; }

        /// <summary>
        /// Gets or Sets the url of the receipt.
        /// </summary>
        public string ReceiptUrl { get; set; }
    }
}

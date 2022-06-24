// <copyright file="Receipt.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Entities
{
    public class Receipt : EntityBase
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

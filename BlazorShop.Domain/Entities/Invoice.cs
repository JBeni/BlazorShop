// <copyright file="Invoice.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Entities
{
    public class Invoice : EntityBase
    {
        /// <summary>
        /// .
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public int AmountSubTotal { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public int AmountTotal { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public int Quantity { get; set; }
    }
}

// <copyright file="Order.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Entities
{
    /// <summary>
    /// A template for the entity order.
    /// </summary>
    public class Order : EntityBase
    {
        /// <summary>
        /// .
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string OrderName { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string LineItems { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public int AmountTotal { get; set; }
    }
}

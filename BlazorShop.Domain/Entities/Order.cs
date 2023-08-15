// <copyright file="Order.cs" company="Beniamin Jitca" author="Beniamin Jitca">
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
        /// Gets or sets the email of the user.
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or sets the name of the order.
        /// </summary>
        public string OrderName { get; set; }

        /// <summary>
        /// Gets or sets the date of the order.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the items of the order.
        /// </summary>
        public string LineItems { get; set; }

        /// <summary>
        /// Gets or sets the total amount of the order.
        /// </summary>
        public int AmountTotal { get; set; }
    }
}

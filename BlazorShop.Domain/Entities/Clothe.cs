// <copyright file="Clothe.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Entities
{
    /// <summary>
    /// A template for the entity clothe.
    /// </summary>
    public class Clothe : EntityBase
    {
        /// <summary>
        /// Gets or Sets the name of the clothe.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or Sets the description of the clothe.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or Sets the price of the clothe.
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Gets or Sets the amount of the clothe.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or Sets the image name of the clothe.
        /// </summary>
        public string? ImageName { get; set; }

        /// <summary>
        /// Gets or Sets the image path of the clothe.
        /// </summary>
        public string? ImagePath { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether the clothe is active or not.
        /// </summary>
        public bool? IsActive { get; set; }
    }
}

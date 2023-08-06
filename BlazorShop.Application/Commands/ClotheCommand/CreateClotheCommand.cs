// <copyright file="CreateClotheCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.ClotheCommand
{
    /// <summary>
    /// A model to create a clothe.
    /// </summary>
    public class CreateClotheCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The name of the clothe.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets The description of the clothe.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets The price of the clothe.
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Gets or sets The amount of the clothe.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets The image name of the clothe.
        /// </summary>
        public string? ImageName { get; set; }

        /// <summary>
        /// Gets or sets The image path of the clothe.
        /// </summary>
        public string? ImagePath { get; set; }

        /// <summary>
        /// Gets or sets The active status of the clothe.
        /// </summary>
        public bool? IsActive { get; set; }
    }
}

// <copyright file="CreateClotheCommand.cs" author="Beniamin Jitca">
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
        /// The name of the clothe.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The description of the clothe.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The price of the clothe.
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// The amount of the clothe.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// The image name of the clothe.
        /// </summary>
        public string? ImageName { get; set; }

        /// <summary>
        /// The image path of the clothe.
        /// </summary>
        public string? ImagePath { get; set; }

        /// <summary>
        /// The active status of the clothe.
        /// </summary>
        public bool? IsActive { get; set; }
    }
}

// <copyright file="CreateClotheCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.ClotheCommand
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class CreateClotheCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? ImageName { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? ImagePath { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public bool? IsActive { get; set; }
    }
}

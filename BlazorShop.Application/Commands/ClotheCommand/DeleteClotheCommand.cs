// <copyright file="DeleteClotheCommand.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.ClotheCommand
{
    /// <summary>
    /// A model to delete a clothe.
    /// </summary>
    public class DeleteClotheCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The id of the clothe.
        /// </summary>
        public int Id { get; set; }
    }
}

// <copyright file="DeleteClotheCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.ClotheCommand
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class DeleteClotheCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}

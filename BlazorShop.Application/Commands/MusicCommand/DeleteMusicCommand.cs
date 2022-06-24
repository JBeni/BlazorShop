// <copyright file="DeleteMusicCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.MusicCommand
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class DeleteMusicCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}

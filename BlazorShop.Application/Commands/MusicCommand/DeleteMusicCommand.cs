// <copyright file="DeleteMusicCommand.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.MusicCommand
{
    /// <summary>
    /// A model to delete a music.
    /// </summary>
    public class DeleteMusicCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// The id of the music.
        /// </summary>
        public int Id { get; set; }
    }
}

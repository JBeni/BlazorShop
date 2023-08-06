// <copyright file="GetMusicByIdQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.MusicQuery
{
    /// <summary>
    /// A model to get the music.
    /// </summary>
    public class GetMusicByIdQuery : IRequest<Result<MusicResponse>>
    {
        /// <summary>
        /// Gets or sets The id of the music.
        /// </summary>
        public int Id { get; set; }
    }
}

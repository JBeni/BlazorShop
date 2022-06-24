// <copyright file="GetMusicByIdQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.MusicQuery
{
    public class GetMusicByIdQuery : IRequest<Result<MusicResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}

// <copyright file="GetMusicByIdQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.MusicQuery
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetMusicByIdQuery : IRequest<Result<MusicResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}

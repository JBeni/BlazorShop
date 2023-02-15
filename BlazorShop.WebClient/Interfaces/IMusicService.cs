// <copyright file="IMusicService.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interfaces
{
    /// <summary>
    /// The service to interact with the music.
    /// </summary>
    public interface IMusicService
    {
        /// <summary>
        /// Get the musics.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<List<MusicResponse>> GetMusics();

        /// <summary>
        /// Get a music.
        /// </summary>
        /// <param name="id">The id of the music.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<MusicResponse> GetMusic(int id);

        /// <summary>
        /// Add a music.
        /// </summary>
        /// <param name="music">The music.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> AddMusic(MusicResponse music);

        /// <summary>
        /// Update a music.
        /// </summary>
        /// <param name="music">The music.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> UpdateMusic(MusicResponse music);

        /// <summary>
        /// Delete a music.
        /// </summary>
        /// <param name="id">The id of the music.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> DeleteMusic(int id);
    }
}

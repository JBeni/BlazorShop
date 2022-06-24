// <copyright file="IMusicService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interfaces
{
    public interface IMusicService
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<List<MusicResponse>> GetMusics();

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<MusicResponse> GetMusic(int id);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<RequestResponse> AddMusic(MusicResponse music);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<RequestResponse> UpdateMusic(MusicResponse music);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<RequestResponse> DeleteMusic(int id);
    }
}

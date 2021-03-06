// <copyright file="UpdateMusicCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.MusicCommand
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class UpdateMusicCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public DateTime DateRelease { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public int AccessLevel { get; set; }
    }
}

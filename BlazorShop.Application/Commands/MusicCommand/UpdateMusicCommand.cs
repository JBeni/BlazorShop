// <copyright file="UpdateMusicCommand.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.MusicCommand
{
    /// <summary>
    /// A model to update a music.
    /// </summary>
    public class UpdateMusicCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// The id of the music.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the music.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The description of the music.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The author of the music.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// The release date of the music.
        /// </summary>
        public DateTime DateRelease { get; set; }

        /// <summary>
        /// The image name of the music.
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// The image path of the music.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// The access level of the music.
        /// </summary>
        public int AccessLevel { get; set; }
    }
}

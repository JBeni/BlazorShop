// <copyright file="CreateMusicCommand.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.MusicCommand
{
    /// <summary>
    /// A model to create a music.
    /// </summary>
    public class CreateMusicCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The id of the music.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets The title of the music.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets The description of the music.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets The author of the music.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets The release date of the music.
        /// </summary>
        public DateTime DateRelease { get; set; }

        /// <summary>
        /// Gets or sets The image name of the music.
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// Gets or sets The image path of the music.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Gets or sets The access level of the music.
        /// </summary>
        public int AccessLevel { get; set; }
    }
}

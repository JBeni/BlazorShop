// <copyright file="Music.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Entities
{
    /// <summary>
    /// A template for the entity music.
    /// </summary>
    public class Music : EntityBase
    {
        /// <summary>
        /// Gets or sets the title of the music.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the music.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the author of the music.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the release date of the music.
        /// </summary>
        public DateTime DateRelease { get; set; }

        /// <summary>
        /// Gets or sets the image name of the music.
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// Gets or sets the image path of the music.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Gets or sets the access level of the music.
        /// </summary>
        public int AccessLevel { get; set; }
    }
}

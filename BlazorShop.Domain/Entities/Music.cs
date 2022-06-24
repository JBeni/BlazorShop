// <copyright file="Music.cs" company="Beniamin Jitca">
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

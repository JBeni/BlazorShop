// <copyright file="MusicResponse.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Responses
{
    /// <summary>
    /// A Music response model.
    /// </summary>
    public class MusicResponse : IMapFrom<Music>
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

        /// <summary>
        /// Convert the entity (Data Access Layer) to model (Business Logic Layer).
        /// </summary>
        /// <param name="profile">The profile to use for the mapping operation.</param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Music, MusicResponse>()
                .ForMember(x => x.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(x => x.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(x => x.Author, opt => opt.MapFrom(s => s.Author))
                .ForMember(x => x.DateRelease, opt => opt.MapFrom(s => s.DateRelease))
                .ForMember(x => x.ImageName, opt => opt.MapFrom(s => s.ImageName))
                .ForMember(x => x.AccessLevel, opt => opt.MapFrom(s => s.AccessLevel))
                .ForMember(x => x.ImagePath, opt => opt.MapFrom(s => s.ImagePath));
        }
    }
}

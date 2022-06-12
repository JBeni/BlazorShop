namespace BlazorShop.Application.Responses
{
    public class MusicResponse : IMapFrom<Music>
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateRelease { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AccessLevel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profile"></param>
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

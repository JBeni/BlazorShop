namespace BlazorShop.Application.Responses
{
    public class MusicResponse : IMapFrom<Music>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime DateRelease { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Music, MusicResponse>()
                .ForMember(x => x.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(x => x.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(x => x.Author, opt => opt.MapFrom(s => s.Author))
                .ForMember(x => x.DateRelease, opt => opt.MapFrom(s => s.DateRelease))
                .ForMember(x => x.ImageName, opt => opt.MapFrom(s => s.ImageName))
                .ForMember(x => x.ImagePath, opt => opt.MapFrom(s => s.ImagePath));
        }

        public string Error { get; set; }
    }
}

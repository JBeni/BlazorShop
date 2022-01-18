namespace BlazorShop.Application.Responses
{
    public class MusicResponse : IMapFrom<Music>
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Music, MusicResponse>()
                .ForMember(x => x.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.Title, opt => opt.MapFrom(s => s.Title));
        }

        public string Error { get; set; }
    }
}

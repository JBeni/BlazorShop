namespace BlazorShop.Application.Responses
{
    public class UserJwtTokenResponse : IMapFrom<UserJwtToken>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? JwtToken { get; set; }
        public DateTime TokenTimestamp { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserJwtToken, UserJwtTokenResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.UserId))
                .ForMember(d => d.JwtToken, opt => opt.MapFrom(s => s.JwtToken))
                .ForMember(d => d.TokenTimestamp, opt => opt.MapFrom(s => s.TokenTimestamp));
        }

        public string? Error { get; set; }
    }
}

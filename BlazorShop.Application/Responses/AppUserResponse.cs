namespace BlazorShop.Application.Responses
{
    public class AppUserResponse : IMapFrom<AppUser>
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AppUser, AppUserResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Username, opt => opt.MapFrom(s => s.Email))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName));
        }

        public string? Error { get; set; }
    }
}

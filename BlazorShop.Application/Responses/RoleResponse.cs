namespace BlazorShop.Application.Responses
{
    public class RoleResponse : IMapFrom<Role>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Role, RoleResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.NormalizedName, opt => opt.MapFrom(s => s.NormalizedName));
        }

        public string? Error { get; set; }
    }
}

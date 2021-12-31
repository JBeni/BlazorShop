namespace BlazorShop.Application.Responses
{
    public class CategoryResponse : IMapFrom<Category>
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
        }

        public string? Error { get; set; }
    }
}

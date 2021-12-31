namespace BlazorShop.Application.Responses
{
    public class ProductPhotoResponse : IMapFrom<ProductPhoto>
    {
        public int Id { get; set; }
        public string? Image { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductPhoto, ProductPhotoResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Image, opt => opt.MapFrom(s => s.RelativePathImage));
        }

        public string? Error { get; set; }
    }
}

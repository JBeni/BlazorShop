namespace BlazorShop.Application.Responses
{
    public class CartResponse : IMapFrom<Cart>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public int ClotheId { get; set; }
        public Clothe Clothe { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Cart, CartResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.Amount, opt => opt.MapFrom(s => s.Amount))
                .ForMember(d => d.ClotheId, opt => opt.MapFrom(s => s.Clothe.Id))
                .ForMember(d => d.Clothe, opt => opt.MapFrom(s => s.Clothe))
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.User.Id))
                .ForMember(d => d.User, opt => opt.MapFrom(s => s.User));
        }

        public string? Error { get; set; }
    }
}

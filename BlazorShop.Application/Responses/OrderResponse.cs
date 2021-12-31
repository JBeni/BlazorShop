namespace BlazorShop.Application.Responses
{
    public class OrderResponse : IMapFrom<Order>
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Quantity, opt => opt.MapFrom(s => s.Quantity));
        }

        public string? Error { get; set; }
    }
}

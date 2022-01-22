namespace BlazorShop.Application.Responses
{
    public class OrderResponse : IMapFrom<Order>
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string OrderName { get; set; }
        public DateTime OrderDate { get; set; }
        public string LineItems { get; set; }
        public int AmountTotal { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.UserEmail, opt => opt.MapFrom(s => s.UserEmail))
                .ForMember(d => d.OrderName, opt => opt.MapFrom(s => s.OrderName))
                .ForMember(d => d.OrderDate, opt => opt.MapFrom(s => s.OrderDate))
                .ForMember(d => d.LineItems, opt => opt.MapFrom(s => s.LineItems))
                .ForMember(d => d.AmountTotal, opt => opt.MapFrom(s => s.AmountTotal));
        }

        public string? Error { get; set; }
    }
}

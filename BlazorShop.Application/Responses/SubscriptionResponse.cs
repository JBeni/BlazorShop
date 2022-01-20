namespace BlazorShop.Application.Responses
{
    public class SubscriptionResponse : IMapFrom<Subscription>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Currency { get; set; }
        public string CurrencySymbol { get; set; }
        public string ChargeType { get; set; }
        public string Options { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Subscription, SubscriptionResponse>()
                .ForMember(x => x.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(x => x.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(x => x.Currency, opt => opt.MapFrom(s => s.Currency))
                .ForMember(x => x.CurrencySymbol, opt => opt.MapFrom(s => s.CurrencySymbol))
                .ForMember(x => x.ChargeType, opt => opt.MapFrom(s => s.ChargeType))
                .ForMember(x => x.Options, opt => opt.MapFrom(s => s.Options));
        }

        public string Error { get; set; }
    }
}

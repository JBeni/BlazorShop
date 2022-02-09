namespace BlazorShop.Application.Responses
{
    public class SubscriptionResponse : IMapFrom<Subscription>
    {
        public int Id { get; set; }
        public string StripeSubscriptionId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Currency { get; set; }
        public string CurrencySymbol { get; set; }
        public string ChargeType { get; set; }
        public string Options { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Subscription, SubscriptionResponse>()
                .ForMember(x => x.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.StripeSubscriptionId, opt => opt.MapFrom(s => s.StripeSubscriptionId))
                .ForMember(x => x.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(x => x.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(x => x.Currency, opt => opt.MapFrom(s => s.Currency))
                .ForMember(x => x.CurrencySymbol, opt => opt.MapFrom(s => s.CurrencySymbol))
                .ForMember(x => x.ChargeType, opt => opt.MapFrom(s => s.ChargeType))
                .ForMember(x => x.ImageName, opt => opt.MapFrom(s => s.ImageName))
                .ForMember(x => x.ImagePath, opt => opt.MapFrom(s => s.ImagePath))
                .ForMember(x => x.Options, opt => opt.MapFrom(s => s.Options));
        }
    }
}

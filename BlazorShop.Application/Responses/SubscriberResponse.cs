namespace BlazorShop.Application.Responses
{
    public class SubscriberResponse : IMapFrom<Subscriber>
    {
        public int Id { get; set; }
        public SubscriptionStatus Status { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime CurrentPeriodEnd { get; set; }
        public int CustomerId { get; set; }
        public User Customer { get; set; }
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Subscriber, SubscriberResponse>()
                .ForMember(x => x.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.Status, opt => opt.MapFrom(s => s.Status))
                .ForMember(x => x.DateStart, opt => opt.MapFrom(s => s.DateStart))
                .ForMember(x => x.CurrentPeriodEnd, opt => opt.MapFrom(s => s.CurrentPeriodEnd))
                .ForMember(x => x.CustomerId, opt => opt.MapFrom(s => s.Customer.Id))
                .ForMember(x => x.Customer, opt => opt.MapFrom(s => s.Customer))
                .ForMember(x => x.SubscriptionId, opt => opt.MapFrom(s => s.Subscription.Id))
                .ForMember(x => x.Subscription, opt => opt.MapFrom(s => s.Subscription));
        }

        public string Error { get; set; }
    }
}

namespace BlazorShop.Application.Responses
{
    public class SubscriberResponse : IMapFrom<Subscriber>
    {
        public int Id { get; set; }
        public SubscriptionStatus Status { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime CurrentPeriodEnd { get; set; }
        public DateTime CurrentPeriodStart { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int SubscriptionId { get; set; }
        public string SubscriptionName { get; set; }
        public string StripeSubscriptionId { get; set; }
        public string CustomerEmail { get; set; }
        public string StripeSubscriberSubscriptionId { get; set; }
        public string HostedInvoiceUrl { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Subscriber, SubscriberResponse>()
                .ForMember(x => x.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.StripeSubscriberSubscriptionId, opt => opt.MapFrom(s => s.StripeSubscriberSubscriptionId))
                .ForMember(x => x.HostedInvoiceUrl, opt => opt.MapFrom(s => s.HostedInvoiceUrl))
                .ForMember(x => x.StripeSubscriptionId, opt => opt.MapFrom(s => s.Subscription.StripeSubscriptionId))
                .ForMember(x => x.Status, opt => opt.MapFrom(s => s.Status))
                .ForMember(x => x.DateStart, opt => opt.MapFrom(s => s.DateStart))
                .ForMember(x => x.CurrentPeriodEnd, opt => opt.MapFrom(s => s.CurrentPeriodEnd))
                .ForMember(x => x.CurrentPeriodStart, opt => opt.MapFrom(s => s.CurrentPeriodStart))
                .ForMember(x => x.CustomerId, opt => opt.MapFrom(s => s.Customer.Id))
                .ForMember(x => x.CustomerName, opt => opt.MapFrom(s => s.Customer.FirstName + " " + s.Customer.LastName))
                .ForMember(x => x.CustomerEmail, opt => opt.MapFrom(s => s.Customer.Email))
                .ForMember(x => x.SubscriptionId, opt => opt.MapFrom(s => s.Subscription.Id))
                .ForMember(x => x.ImageName, opt => opt.MapFrom(s => s.Subscription.ImageName))
                .ForMember(x => x.ImagePath, opt => opt.MapFrom(s => s.Subscription.ImagePath))
                .ForMember(x => x.SubscriptionName, opt => opt.MapFrom(s => s.Subscription.Name));
        }

        public string Error { get; set; }
    }
}

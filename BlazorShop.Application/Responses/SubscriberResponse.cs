// <copyright file="SubscriberResponse.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Responses
{
    public class SubscriberResponse : IMapFrom<Subscriber>
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SubscriptionStatus Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CurrentPeriodEnd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CurrentPeriodStart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SubscriptionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SubscriptionName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string StripeSubscriptionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string StripeSubscriberSubscriptionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string HostedInvoiceUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profile"></param>
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
    }
}

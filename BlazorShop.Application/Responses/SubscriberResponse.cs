// <copyright file="SubscriberResponse.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Responses
{
    /// <summary>
    /// A Subscriber response model.
    /// </summary>
    public class SubscriberResponse : IMapFrom<Subscriber>
    {
        /// <summary>
        /// The id of the subscriber.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The status of the subscription.
        /// </summary>
        public SubscriptionStatus Status { get; set; }

        /// <summary>
        /// The started date of the subscriber.
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// The date when the current period ends.
        /// </summary>
        public DateTime CurrentPeriodEnd { get; set; }

        /// <summary>
        /// The date when the current period starts.
        /// </summary>
        public DateTime CurrentPeriodStart { get; set; }

        /// <summary>
        /// The id of the customer.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// The name of the customer.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// The id of the subscription.
        /// </summary>
        public int SubscriptionId { get; set; }

        /// <summary>
        /// The name of the subscription.
        /// </summary>
        public string SubscriptionName { get; set; }

        /// <summary>
        /// The id of the stripe subscription.
        /// </summary>
        public string StripeSubscriptionId { get; set; }

        /// <summary>
        /// The email of the customer.
        /// </summary>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// The id of the stripe subscriber subscription.
        /// </summary>
        public string StripeSubscriberSubscriptionId { get; set; }

        /// <summary>
        /// The url of the invoice.
        /// </summary>
        public string HostedInvoiceUrl { get; set; }

        /// <summary>
        /// The image name of the subscriber.
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// The image path of the subscriber.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Convert the entity (Data Access Layer) to model (Business Logic Layer).
        /// </summary>
        /// <param name="profile">The profile to use for the mapping operation.</param>
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

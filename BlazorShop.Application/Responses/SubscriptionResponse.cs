// <copyright file="SubscriptionResponse.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Responses
{
    /// <summary>
    /// A Subscription response model.
    /// </summary>
    public class SubscriptionResponse : IMapFrom<Subscription>
    {
        /// <summary>
        /// Gets or sets The id of the subscription.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets The id of the stripe subscription.
        /// </summary>
        public string StripeSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets The name of the subscription.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets The price of the subscription.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets The currency of the subscription.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets The currency symbol of the subscription.
        /// </summary>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets The charge type of the subscription.
        /// </summary>
        public string ChargeType { get; set; }

        /// <summary>
        /// Gets or sets The options of the subscription.
        /// </summary>
        public string Options { get; set; }

        /// <summary>
        /// Gets or sets The image name of the subscription.
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// Gets or sets The image path of the subscription.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Convert the entity (Data Access Layer) to model (Business Logic Layer).
        /// </summary>
        /// <param name="profile">The profile to use for the mapping operation.</param>
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

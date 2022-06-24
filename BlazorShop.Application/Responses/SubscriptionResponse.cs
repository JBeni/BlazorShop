// <copyright file="SubscriptionResponse.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Responses
{
    public class SubscriptionResponse : IMapFrom<Subscription>
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string StripeSubscriptionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ChargeType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Options { get; set; }

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

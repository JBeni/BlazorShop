// <copyright file="OrderResponse.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Responses
{
    public class OrderResponse : IMapFrom<Order>
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OrderName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LineItems { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AmountTotal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profile"></param>
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
    }
}

// <copyright file="OrderResponse.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Responses
{
    /// <summary>
    /// An Order response model.
    /// </summary>
    public class OrderResponse : IMapFrom<Order>
    {
        /// <summary>
        /// Gets or sets The id of the order.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets The email of the user.
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or sets The name of the order.
        /// </summary>
        public string OrderName { get; set; }

        /// <summary>
        /// Gets or sets The date when the order was placed.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets The items of the order.
        /// </summary>
        public string LineItems { get; set; }

        /// <summary>
        /// Gets or sets The total amount of the order.
        /// </summary>
        public int AmountTotal { get; set; }

        /// <summary>
        /// Convert the entity (Data Access Layer) to model (Business Logic Layer).
        /// </summary>
        /// <param name="profile">The profile to use for the mapping operation.</param>
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

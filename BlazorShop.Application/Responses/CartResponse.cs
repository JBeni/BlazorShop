// <copyright file="CartResponse.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Responses
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class CartResponse : IMapFrom<Cart>
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ClotheId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ClotheName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ClotheImageName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ClotheImagePath { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="profile"></param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Cart, CartResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.Amount, opt => opt.MapFrom(s => s.Amount))
                .ForMember(d => d.ClotheId, opt => opt.MapFrom(s => s.Clothe.Id))
                .ForMember(d => d.ClotheName, opt => opt.MapFrom(s => s.Clothe.Name))
                .ForMember(d => d.ClotheImageName, opt => opt.MapFrom(s => s.Clothe.ImageName))
                .ForMember(d => d.ClotheImagePath, opt => opt.MapFrom(s => s.Clothe.ImagePath))
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.User.Id));
        }
    }
}

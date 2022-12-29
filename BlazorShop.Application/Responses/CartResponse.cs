// <copyright file="CartResponse.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Responses
{
    /// <summary>
    /// A Cart response model.
    /// </summary>
    public class CartResponse : IMapFrom<Cart>
    {
        /// <summary>
        /// The id of the cart.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the cart.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The price of the cart.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The amount of the cart.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// The id of the clothe.
        /// </summary>
        public int ClotheId { get; set; }

        /// <summary>
        /// The name of the clothe.
        /// </summary>
        public string ClotheName { get; set; }

        /// <summary>
        /// The image name of the clothe.
        /// </summary>
        public string ClotheImageName { get; set; }

        /// <summary>
        /// The image path of the clothe.
        /// </summary>
        public string ClotheImagePath { get; set; }

        /// <summary>
        /// The id of the user.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Convert the entity (Data Access Layer) to model (Business Logic Layer).
        /// </summary>
        /// <param name="profile">The profile to use for the mapping operation.</param>
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

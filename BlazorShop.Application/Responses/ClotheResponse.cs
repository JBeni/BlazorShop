// <copyright file="ClotheResponse.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Responses
{
    /// <summary>
    /// A Clothe response model.
    /// </summary>
    public class ClotheResponse : IMapFrom<Clothe>
    {
        /// <summary>
        /// The id of the clothe.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the clothe.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The description of the clothe.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The price of the clothe.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The amount of the clothe.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// The image name of the clothe.
        /// </summary>
        public string? ImageName { get; set; }

        /// <summary>
        /// The image path of the clothe.
        /// </summary>
        public string? ImagePath { get; set; }

        /// <summary>
        /// The status of the clothe.
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Convert the entity (Data Access Layer) to model (Business Logic Layer).
        /// </summary>
        /// <param name="profile">The profile to use for the mapping operation.</param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Clothe, ClotheResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.Amount, opt => opt.MapFrom(s => s.Amount))
                .ForMember(d => d.ImageName, opt => opt.MapFrom(s => s.ImageName))
                .ForMember(d => d.ImagePath, opt => opt.MapFrom(s => s.ImagePath))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(s => s.IsActive));
        }
    }
}

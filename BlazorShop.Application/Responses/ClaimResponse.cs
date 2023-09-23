// <copyright file="ClaimResponse.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Responses
{
    /// <summary>
    /// A Claim response model.
    /// </summary>
    public class ClaimResponse : IMapFrom<CustomClaim>
    {
        /// <summary>
        /// Gets or sets The id of the Claim.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets The value of the Claim.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets The type of the Claim.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Convert the entity (Data Access Layer) to model (Business Logic Layer).
        /// </summary>
        /// <param name="profile">The profile to use for the mapping operation.</param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CustomClaim, ClaimResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Value, opt => opt.MapFrom(s => s.ClaimValue))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.ClaimType));
        }
    }
}

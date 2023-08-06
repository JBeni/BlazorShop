// <copyright file="RoleResponse.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Responses
{
    /// <summary>
    /// A Role response model.
    /// </summary>
    public class RoleResponse : IMapFrom<Role>
    {
        /// <summary>
        /// Gets or sets The id of the role.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets The name of the role.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets The normalized name of the role.
        /// </summary>
        public string? NormalizedName { get; set; }

        /// <summary>
        /// Convert the entity (Data Access Layer) to model (Business Logic Layer).
        /// </summary>
        /// <param name="profile">The profile to use for the mapping operation.</param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Role, RoleResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.NormalizedName, opt => opt.MapFrom(s => s.NormalizedName));
        }
    }
}

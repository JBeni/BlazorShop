// <copyright file="UserResponse.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Responses
{
    /// <summary>
    /// An User response model.
    /// </summary>
    public class UserResponse : IMapFrom<User>
    {
        /// <summary>
        /// Gets or sets The id of the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets The username of the user.
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets The email of the user.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets The firstname of the user.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets The lastname of the user.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets The id of the role.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets The name of the role.
        /// </summary>
        public string? RoleName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is active or not.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Convert the entity (Data Access Layer) to model (Business Logic Layer).
        /// </summary>
        /// <param name="profile">The profile to use for the mapping operation.</param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Username, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(d => d.RoleId, opt => opt.MapFrom(s => s.Roles.Count))
                .ForMember(d => d.RoleName, opt => opt.MapFrom(s =>
                    s.Roles.Where(x => x.UserId == x.User.Id).Select(x => x.Role.Name).FirstOrDefault()))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(s => s.IsActive));
        }
    }
}

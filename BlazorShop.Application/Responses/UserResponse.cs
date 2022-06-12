namespace BlazorShop.Application.Responses
{
    public class UserResponse : IMapFrom<User>
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? RoleName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profile"></param>
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

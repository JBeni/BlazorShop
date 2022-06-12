namespace BlazorShop.Application.Responses
{
    public class ClotheResponse : IMapFrom<Clothe>
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
        public string? Description { get; set; }

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
        public string? ImageName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? ImagePath { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profile"></param>
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

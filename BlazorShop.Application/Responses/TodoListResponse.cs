namespace BlazorShop.Application.Responses
{
    public class TodoListResponse : IMapFrom<TodoList>
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<TodoItemResponse> Items { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profile"></param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TodoList, TodoListResponse>()
                .ForMember(x => x.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(x => x.Items, opt => opt.MapFrom(s => s.Items));
        }
    }
}

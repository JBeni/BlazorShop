namespace BlazorShop.Application.Responses
{
    public class TodoListResponse : IMapFrom<TodoList>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public List<TodoItemResponse> Items { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TodoList, TodoListResponse>()
                .ForMember(x => x.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(x => x.Items, opt => opt.MapFrom(s => s.Items));
        }
    }
}

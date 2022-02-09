namespace BlazorShop.Application.Responses
{
    public class TodoItemResponse : IMapFrom<TodoItem>
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public string? Title { get; set; }
        public string? Note { get; set; }
        public TodoItemPriority Priority { get; set; }
        public TodoItemState State { get; set; }
        public bool Done { get; set; }
        public TodoListResponse List { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TodoItem, TodoItemResponse>()
                .ForMember(x => x.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(x => x.Note, opt => opt.MapFrom(s => s.Note))
                .ForMember(x => x.Priority, opt => opt.MapFrom(s => s.Priority))
                .ForMember(x => x.State, opt => opt.MapFrom(s => s.State))
                .ForMember(x => x.Done, opt => opt.MapFrom(s => s.Done))
                .ForMember(x => x.List, opt => opt.MapFrom(s => s.List));
        }
    }
}

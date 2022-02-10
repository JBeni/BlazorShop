namespace BlazorShop.Application.Commands.TodoItemCommand
{
    public class CreateTodoItemCommand : IRequest<Result<TodoItemResponse>>
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public string? Title { get; set; }
        public string? Note { get; set; }
        public TodoItemPriority Priority { get; set; }
        public TodoItemState State { get; set; }
    }
}

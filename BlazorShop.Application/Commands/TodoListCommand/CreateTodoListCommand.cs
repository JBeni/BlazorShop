namespace BlazorShop.Application.Commands.TodoListCommand
{
    public class CreateTodoListCommand : IRequest<Result<TodoListResponse>>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
    }
}

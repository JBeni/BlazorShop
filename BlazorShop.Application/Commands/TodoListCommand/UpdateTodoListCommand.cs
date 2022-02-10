namespace BlazorShop.Application.Commands.TodoListCommand
{
    public class UpdateTodoListCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
    }
}

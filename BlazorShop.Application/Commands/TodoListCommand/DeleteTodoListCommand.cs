namespace BlazorShop.Application.Commands.TodoListCommand
{
    public class DeleteTodoListCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
    }
}

namespace BlazorShop.Application.Commands.TodoItemCommand
{
    public class DeleteTodoItemCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
    }
}

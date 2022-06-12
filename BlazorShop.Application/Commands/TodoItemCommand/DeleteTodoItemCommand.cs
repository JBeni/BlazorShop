namespace BlazorShop.Application.Commands.TodoItemCommand
{
    public class DeleteTodoItemCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}

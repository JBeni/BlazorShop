namespace BlazorShop.Application.Commands.TodoListCommand
{
    public class DeleteTodoListCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}

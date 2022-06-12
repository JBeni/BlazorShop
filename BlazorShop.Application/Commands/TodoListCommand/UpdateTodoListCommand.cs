namespace BlazorShop.Application.Commands.TodoListCommand
{
    public class UpdateTodoListCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Title { get; set; }
    }
}

namespace BlazorShop.Application.Queries.TodoItemQuery
{
    public class GetTodoItemByIdQuery : IRequest<Result<TodoItemResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}

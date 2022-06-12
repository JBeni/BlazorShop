namespace BlazorShop.Application.Queries.TodoListQuery
{
    public class GetTodoListByIdQuery : IRequest<Result<TodoListResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}

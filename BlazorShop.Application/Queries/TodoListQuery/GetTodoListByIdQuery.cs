namespace BlazorShop.Application.Queries.TodoListQuery
{
    public class GetTodoListByIdQuery : IRequest<Result<TodoListResponse>>
    {
        public int Id { get; set; }
    }
}

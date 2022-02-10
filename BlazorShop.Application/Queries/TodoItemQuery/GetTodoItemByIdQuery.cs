namespace BlazorShop.Application.Queries.TodoItemQuery
{
    public class GetTodoItemByIdQuery : IRequest<Result<TodoItemResponse>>
    {
        public int Id { get; set; }
    }
}

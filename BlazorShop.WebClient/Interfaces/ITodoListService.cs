namespace BlazorShop.WebClient.Interfaces
{
    public interface ITodoListService
    {
        Task<List<TodoListResponse>> GetTodoListsAsync();
        Task<TodoListResponse> GetTodoListAsync(int id);
        Task<TodoListResponse> PostTodoListAsync(TodoListResponse todoList);
        Task<RequestResponse> PutTodoListAsync(TodoListResponse todoList);
        Task<RequestResponse> DeleteTodoListAsync(int id);
    }
}

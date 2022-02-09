namespace BlazorShop.WebClient.Interfaces
{
    public interface ITodoItemService
    {
        Task<TodoItemResponse> GetTodoItemAsync(int id);
        Task<RequestResponse> PutTodoItemAsync(TodoItemResponse todoItem);
        Task<RequestResponse> DeleteTodoItemAsync(int id);
        Task<TodoItemResponse> PostTodoItemAsync(TodoItemResponse todoItem);
    }
}

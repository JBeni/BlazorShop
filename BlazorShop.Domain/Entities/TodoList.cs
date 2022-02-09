namespace BlazorShop.Domain.Entities
{
    public class TodoList : EntityBase
    {
        public string? Title { get; set; }

        public virtual ICollection<TodoItem> Items { get; set; }
    }
}

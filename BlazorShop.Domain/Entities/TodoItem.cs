namespace BlazorShop.Domain.Entities
{
    public class TodoItem : EntityBase
    {
        public string? Title { get; set; }
        public string? Note { get; set; }
        public TodoItemPriority Priority { get; set; }
        public TodoItemState State { get; set; }
        public bool Done { get; set; }

        public TodoList List { get; set; }
    }
}

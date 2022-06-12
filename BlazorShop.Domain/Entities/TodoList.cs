namespace BlazorShop.Domain.Entities
{
    public class TodoList : EntityBase
    {
        /// <summary>
        /// .
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public virtual ICollection<TodoItem> Items { get; set; }
    }
}

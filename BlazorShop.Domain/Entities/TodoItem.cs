namespace BlazorShop.Domain.Entities
{
    public class TodoItem : EntityBase
    {
        /// <summary>
        /// .
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Note { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public TodoItemPriority Priority { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public TodoItemState State { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public bool Done { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public TodoList List { get; set; }
    }
}

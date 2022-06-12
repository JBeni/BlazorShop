namespace BlazorShop.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        /// <summary>
        /// .
        /// </summary>
        DbSet<Cart> Carts { get; set; }

        /// <summary>
        /// .
        /// </summary>
        DbSet<Clothe> Clothes { get; set; }

        /// <summary>
        /// .
        /// </summary>
        DbSet<Invoice> Invoices { get; set; }

        /// <summary>
        /// .
        /// </summary>
        DbSet<Music> Musics { get; set; }

        /// <summary>
        /// .
        /// </summary>
        DbSet<Order> Orders { get; set; }

        /// <summary>
        /// .
        /// </summary>
        DbSet<Subscriber> Subscribers { get; set; }

        /// <summary>
        /// .
        /// </summary>
        DbSet<Subscription> Subscriptions { get; set; }

        /// <summary>
        /// .
        /// </summary>
        DbSet<Receipt> Receipts { get; set; }

        /// <summary>
        /// .
        /// </summary>
        DbSet<TodoItem> TodoItems { get; set; }

        /// <summary>
        /// .
        /// </summary>
        DbSet<TodoList> TodoLists { get; set; }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

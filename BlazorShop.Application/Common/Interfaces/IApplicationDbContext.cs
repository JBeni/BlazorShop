namespace BlazorShop.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Cart> Carts { get; set; }
        DbSet<Clothe> Clothes { get; set; }
        DbSet<Invoice> Invoices { get; set; }
        DbSet<Music> Musics { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Subscriber> Subscribers { get; set; }
        DbSet<Subscription> Subscriptions { get; set; }
        DbSet<Receipt> Receipts { get; set; }
        DbSet<TodoItem> TodoItems { get; set; }
        DbSet<TodoList> TodoLists { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

namespace BlazorShop.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Clothe> Clothes { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

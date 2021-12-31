namespace BlazorShop.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Brand> Brands { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Color> Colors { get; set; }
        DbSet<Invoice> Invoices { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductPhoto> ProductPhotos { get; set; }
        DbSet<ProductSize> ProductSizes { get; set; }
        DbSet<Receipt> Receipts { get; set; }
        DbSet<UserJwtToken> UserJwtTokens { get; set; }
        DbSet<Size> Sizes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

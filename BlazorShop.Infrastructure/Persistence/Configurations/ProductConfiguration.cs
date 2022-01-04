namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(p => p.Price)
                .HasColumnType("decimal(18, 2)");
        }
    }
}

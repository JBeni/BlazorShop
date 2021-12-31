namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    public class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder.ToTable("ProductSizes");

            builder.Property(t => t.Id)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}

namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    public class ProductPhotoConfiguration : IEntityTypeConfiguration<ProductPhoto>
    {
        public void Configure(EntityTypeBuilder<ProductPhoto> builder)
        {
            builder.ToTable("ProductPhotos");

            builder.Property(t => t.RelativePathImage)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}

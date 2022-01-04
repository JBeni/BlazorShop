namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    public class ClotheConfiguration : IEntityTypeConfiguration<Clothe>
    {
        public void Configure(EntityTypeBuilder<Clothe> builder)
        {
            builder.ToTable("Clothes");

            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(p => p.Price)
                .HasColumnType("decimal(18, 2)");
        }
    }
}

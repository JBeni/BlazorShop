namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.ToTable("Receipts");

            builder.Property(t => t.ReceiptDate)
                .IsRequired();
            builder.Property(t => t.ReceiptName)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.ReceiptUrl)
                .HasMaxLength(500)
                .IsRequired();
        }
    }
}

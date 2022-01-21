namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");

            builder.Property(t => t.UserEmail)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.AmountSubTotal)
                .IsRequired();
            builder.Property(t => t.AmountTotal)
                .IsRequired();
            builder.Property(t => t.Quantity)
                .IsRequired();
        }
    }
}

namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");

            builder.Property(t => t.ProvidedBy)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}

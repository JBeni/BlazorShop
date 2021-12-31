namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");

            builder.Property(t => t.Amount)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}

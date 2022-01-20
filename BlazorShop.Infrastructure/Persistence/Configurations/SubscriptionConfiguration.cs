namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable("Subscriptions");

            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.Price)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
            builder.Property(t => t.Currency)
                .IsRequired();
            builder.Property(t => t.CurrencySymbol)
                .IsRequired();
            builder.Property(t => t.ChargeType)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(t => t.Options)
                .HasMaxLength(500)
                .IsRequired();
        }
    }
}

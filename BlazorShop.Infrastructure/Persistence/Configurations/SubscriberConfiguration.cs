namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    public class SubscriberConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.ToTable("Subscribers");
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Status)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(t => t.DateStart)
                .IsRequired();
            builder.Property(t => t.CurrentPeriodEnd)
                .IsRequired();
            builder.Property(t => t.CurrentPeriodStart)
                .IsRequired();
            builder.Property(t => t.StripeSubscriberSubscriptionId)
                .HasMaxLength(500)
                .IsRequired();
            builder.Property(t => t.HostedInvoiceUrl)
                .HasMaxLength(700)
                .IsRequired();
        }
    }
}

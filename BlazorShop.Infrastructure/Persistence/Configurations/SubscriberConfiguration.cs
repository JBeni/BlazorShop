namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    public class SubscriberConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.ToTable("Subscribers");

            builder.Property(t => t.Status)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.DateStart)
                .IsRequired();
            builder.Property(t => t.CurrentPeriodEnd)
                .IsRequired();
        }
    }
}

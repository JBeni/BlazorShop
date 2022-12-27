// <copyright file="SubscriberConfiguration.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    /// <summary>
    /// The configuration for the entity <see cref="Subscriber"/>.
    /// </summary>
    public class SubscriberConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="builder"></param>
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

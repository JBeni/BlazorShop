// <copyright file="OrderConfiguration.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    /// <summary>
    /// The configuration for the entity <see cref="Order"/>.
    /// </summary>
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);

            builder.Property(t => t.UserEmail)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(t => t.OrderName)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.OrderDate)
                .IsRequired();
            builder.Property(t => t.LineItems)
                .HasMaxLength(10000)
                .IsRequired();
            builder.Property(t => t.AmountTotal)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}

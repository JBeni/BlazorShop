// <copyright file="OrderConfiguration.cs" company="Beniamin Jitca" author="Beniamin Jitca">
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
        /// A method to configure an entity.
        /// </summary>
        /// <param name="builder">The builder for configuring the entity metadata.</param>
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

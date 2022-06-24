// <copyright file="OrderConfiguration.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
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

﻿namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.Property(t => t.Description)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
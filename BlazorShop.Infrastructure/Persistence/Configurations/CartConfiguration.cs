// <copyright file="CartConfiguration.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    /// <summary>
    /// The configuration for the entity <see cref="Cart"/>.
    /// </summary>
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(p => p.Price)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
            builder.Property(t => t.Amount)
                .IsRequired();
        }
    }
}

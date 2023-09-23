// <copyright file="CustomClaimConfiguration.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    /// <summary>
    /// The configuration for the entity <see cref="CustomClaim"/>.
    /// </summary>
    public class CustomClaimConfiguration : IEntityTypeConfiguration<CustomClaim>
    {
        /// <summary>
        /// A method to configure an entity.
        /// </summary>
        /// <param name="builder">The builder for configuring the entity metadata.</param>
        public void Configure(EntityTypeBuilder<CustomClaim> builder)
        {
            builder.ToTable("CustomClaims");

            builder.HasKey(x => x.Id);

            builder.Property(t => t.ClaimType)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(t => t.ClaimValue)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}

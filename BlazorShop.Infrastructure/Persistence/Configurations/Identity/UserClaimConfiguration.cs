// <copyright file="UserClaimConfiguration.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Persistence.Configurations.Identity
{
    /// <summary>
    /// The configuration for the entity <see cref="UserClaim"/>.
    /// </summary>
    public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        /// <summary>
        /// A method to configure an entity.
        /// </summary>
        /// <param name="builder">The builder for configuring the entity metadata.</param>
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.ToTable("AppUserClaims");

            builder.HasOne(userClaim => userClaim.User)
                .WithMany(user => user.Claims)
                .HasForeignKey(userClaim => userClaim.UserId);

            builder.Property(x => x.ClaimType)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(x => x.ClaimValue)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}

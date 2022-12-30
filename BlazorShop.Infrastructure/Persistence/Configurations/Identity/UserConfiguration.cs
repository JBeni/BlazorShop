// <copyright file="UserConfiguration.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Persistence.Configurations.Identity
{
    /// <summary>
    /// The configuration for the entity <see cref="User"/>.
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// A method to configure an entity.
        /// </summary>
        /// <param name="builder">The builder for configuring the entity metadata.</param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("AppUsers");

            builder.Property(x => x.FirstName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.LastName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.IsActive)
                .IsRequired();

            builder.Property(x => x.UserName)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(x => x.NormalizedUserName)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(x => x.Email)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(x => x.NormalizedEmail)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}

// <copyright file="UserRoleConfiguration.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Persistence.Configurations.Identity
{
    /// <summary>
    /// The configuration for the entity <see cref="UserRole"/>.
    /// </summary>
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("AppUserRoles");

            builder.HasOne(userRole => userRole.Role)
                .WithMany(role => role.Users)
                .HasForeignKey(userRole => userRole.RoleId);
            builder.HasOne(userRole => userRole.User)
                .WithMany(user => user.Roles)
                .HasForeignKey(userRole => userRole.UserId);
        }
    }
}

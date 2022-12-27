// <copyright file="UserLoginConfiguration.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Persistence.Configurations.Identity
{
    /// <summary>
    /// The configuration for the entity <see cref="UserLogin"/>.
    /// </summary>
    public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.ToTable("AppUserLogins");

            builder.HasOne(userLogin => userLogin.User)
                .WithMany(user => user.Logins)
                .HasForeignKey(userLogin => userLogin.UserId);
        }
    }
}

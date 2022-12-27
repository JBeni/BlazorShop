// <copyright file="UserTokenConfiguration.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Persistence.Configurations.Identity
{
    /// <summary>
    /// The configuration for the entity <see cref="UserToken"/>.
    /// </summary>
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.ToTable("AppUserTokens");

            builder.HasOne(userToken => userToken.User)
                .WithMany(user => user.UserTokens)
                .HasForeignKey(userToken => userToken.UserId);
        }
    }
}

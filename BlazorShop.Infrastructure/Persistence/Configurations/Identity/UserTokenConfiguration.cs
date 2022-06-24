// <copyright file="UserTokenConfiguration.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Persistence.Configurations.Identity
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.ToTable("AppUserTokens");

            builder.HasOne(userToken => userToken.User)
                .WithMany(user => user.UserTokens)
                .HasForeignKey(userToken => userToken.UserId);
/*
            builder.Property(x => x.LoginProvider)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(x => x.Name)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(x => x.Value)
                .HasMaxLength(1000)
                .IsRequired();
*/
        }
    }
}

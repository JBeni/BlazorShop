// <copyright file="UserLoginConfiguration.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Persistence.Configurations.Identity
{
    public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.ToTable("AppUserLogins");

            builder.HasOne(userLogin => userLogin.User)
                .WithMany(user => user.Logins)
                .HasForeignKey(userLogin => userLogin.UserId);
/*
            builder.Property(x => x.LoginProvider)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(x => x.ProviderKey)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(x => x.ProviderDisplayName)
                .HasMaxLength(150)
                .IsRequired();
*/
        }
    }
}

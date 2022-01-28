namespace BlazorShop.Infrastructure.Persistence.Configurations.Id
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.ToTable("AppUserClaims");
            builder.HasKey(x => x.Id);

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

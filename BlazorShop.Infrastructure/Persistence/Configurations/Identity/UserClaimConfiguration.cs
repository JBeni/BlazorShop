namespace BlazorShop.Infrastructure.Persistence.Configurations.Id
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.ToTable("AppUserClaims");

            builder.HasOne(userClaim => userClaim.User)
                .WithMany(user => user.Claims)
                .HasForeignKey(userClaim => userClaim.UserId);
        }
    }
}

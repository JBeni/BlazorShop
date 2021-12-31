namespace BlazorShop.Infrastructure.Persistence.Configurations.Id
{
    public class AppUserClaimConfiguration : IEntityTypeConfiguration<AppUserClaim>
    {
        public void Configure(EntityTypeBuilder<AppUserClaim> builder)
        {
            builder.ToTable("AppUserClaims");
        }
    }
}

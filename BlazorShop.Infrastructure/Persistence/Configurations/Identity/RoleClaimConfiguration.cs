namespace BlazorShop.Infrastructure.Persistence.Configurations.Id
{
    public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.ToTable("AppRoleClaims");

            builder.HasOne(roleClaim => roleClaim.Role)
                .WithMany(role => role.Claims)
                .HasForeignKey(roleClaim => roleClaim.RoleId);
        }
    }
}

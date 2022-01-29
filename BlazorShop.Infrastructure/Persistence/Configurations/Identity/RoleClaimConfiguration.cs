namespace BlazorShop.Infrastructure.Persistence.Configurations.Identity
{
    public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.ToTable("AppRoleClaims");

            builder.HasOne(roleClaim => roleClaim.Role)
                .WithMany(role => role.Claims)
                .HasForeignKey(roleClaim => roleClaim.RoleId);

            builder.Property(x => x.ClaimType)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(x => x.ClaimValue)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}

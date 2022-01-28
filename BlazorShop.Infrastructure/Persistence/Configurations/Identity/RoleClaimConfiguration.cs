namespace BlazorShop.Infrastructure.Persistence.Configurations.Id
{
    public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.ToTable("AppRoleClaims");
            builder.HasKey(x => x.Id);

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

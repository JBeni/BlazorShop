namespace BlazorShop.Infrastructure.Persistence.Configurations.Identity
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("AppRoles");

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.NormalizedName)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}

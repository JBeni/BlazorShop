namespace BlazorShop.Infrastructure.Persistence.Configurations.Id
{
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.ToTable("AppUserRoles");
        }
    }
}

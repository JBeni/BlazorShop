namespace BlazorShop.Infrastructure.Persistence.Configurations.Id
{
    public class AppUserLoginConfiguration : IEntityTypeConfiguration<AppUserLogin>
    {
        public void Configure(EntityTypeBuilder<AppUserLogin> builder)
        {
            builder.ToTable("AppUserLogins");
        }
    }
}

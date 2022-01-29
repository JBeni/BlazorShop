namespace BlazorShop.Infrastructure.Persistence.Configurations.Identity
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("AppUserRoles");

            builder.HasOne(userRole => userRole.Role)
                .WithMany(role => role.Users)
                .HasForeignKey(userRole => userRole.RoleId);
            builder.HasOne(userRole => userRole.User)
                .WithMany(user => user.Roles)
                .HasForeignKey(userRole => userRole.UserId);
        }
    }
}

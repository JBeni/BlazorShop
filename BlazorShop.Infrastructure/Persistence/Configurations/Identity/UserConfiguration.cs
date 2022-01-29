namespace BlazorShop.Infrastructure.Persistence.Configurations.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("AppUsers");

            builder.Property(x => x.FirstName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.LastName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.IsActive)
                .IsRequired();

            builder.Property(x => x.UserName)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(x => x.NormalizedUserName)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(x => x.Email)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(x => x.NormalizedEmail)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.PasswordHash)
                .IsRequired();
            builder.Property(x => x.SecurityStamp)
                .IsRequired();
            builder.Property(x => x.ConcurrencyStamp)
                .IsRequired();
        }
    }
}

namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    public class MusicConfiguration : IEntityTypeConfiguration<Music>
    {
        public void Configure(EntityTypeBuilder<Music> builder)
        {
            builder.ToTable("Musics");
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Title)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.Description)
                .HasMaxLength(1000)
                .IsRequired();
            builder.Property(t => t.Author)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.DateRelease)
                .IsRequired();
            builder.Property(t => t.ImageName)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.ImagePath)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.AccessLevel)
                .IsRequired();
        }
    }
}

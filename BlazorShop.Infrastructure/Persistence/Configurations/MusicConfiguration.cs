// <copyright file="MusicConfiguration.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    /// <summary>
    /// The configuration for the entity <see cref="Music"/>.
    /// </summary>
    public class MusicConfiguration : IEntityTypeConfiguration<Music>
    {
        /// <summary>
        /// A method to configure an entity.
        /// </summary>
        /// <param name="builder">The builder for configuring the entity metadata.</param>
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

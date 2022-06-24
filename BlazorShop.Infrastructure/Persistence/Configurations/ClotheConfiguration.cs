// <copyright file="ClotheConfiguration.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    public class ClotheConfiguration : IEntityTypeConfiguration<Clothe>
    {
        public void Configure(EntityTypeBuilder<Clothe> builder)
        {
            builder.ToTable("Clothes");
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.Description)
                .HasMaxLength(1000)
                .IsRequired();
            builder.Property(p => p.Price)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
            builder.Property(p => p.Amount)
                .IsRequired();
            builder.Property(t => t.ImageName)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.ImagePath)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.IsActive)
                .IsRequired();
        }
    }
}

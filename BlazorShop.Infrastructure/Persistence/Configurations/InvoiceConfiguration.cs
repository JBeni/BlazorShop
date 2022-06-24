// <copyright file="InvoiceConfiguration.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");
            builder.HasKey(x => x.Id);

            builder.Property(t => t.UserEmail)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.AmountSubTotal)
                .IsRequired();
            builder.Property(t => t.AmountTotal)
                .IsRequired();
            builder.Property(t => t.Quantity)
                .IsRequired();
        }
    }
}

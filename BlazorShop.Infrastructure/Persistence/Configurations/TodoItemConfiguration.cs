// <copyright file="TodoItemConfiguration.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    /// <summary>
    /// The configuration for the entity <see cref="TodoItem"/>.
    /// </summary>
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        /// <summary>
        /// A method to configure an entity.
        /// </summary>
        /// <param name="builder">The builder for configuring the entity metadata.</param>
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.ToTable("TodoItems");
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Title)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.Note)
                .HasMaxLength(1000);
        }
    }
}

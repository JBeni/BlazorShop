// <copyright file="TodoListConfiguration.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    /// <summary>
    /// The configuration for the entity <see cref="TodoList"/>.
    /// </summary>
    public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
    {
        /// <summary>
        /// A method to configure an entity.
        /// </summary>
        /// <param name="builder">The builder for configuring the entity metadata.</param>
        public void Configure(EntityTypeBuilder<TodoList> builder)
        {
            builder.ToTable("TodoLists");
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Title)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}

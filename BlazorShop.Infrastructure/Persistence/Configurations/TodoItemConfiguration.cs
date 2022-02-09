namespace BlazorShop.Infrastructure.Persistence.Configurations
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.ToTable("TodoItems");
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Title)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.Note)
                .HasMaxLength(1000)
                .IsRequired();
            builder.Property(t => t.Priority)
                .IsRequired();
            builder.Property(t => t.State)
                .IsRequired();
            builder.Property(t => t.Done)
                .IsRequired();
        }
    }
}

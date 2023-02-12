// <copyright file="ApplicationDbContext.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Persistence
{
    /// <summary>
    /// The database context configurations and entities.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<User, Role, int,
        UserClaim, UserRole, UserLogin,
        RoleClaim, UserToken>, IApplicationDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options for the db context.</param>
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options for the db context.</param>
        protected ApplicationDbContext(
            DbContextOptions options)

            : base(options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        protected ApplicationDbContext()
        {
        }

        /// <inheritdoc/>
        public DbSet<Cart> Carts { get; set; }

        /// <inheritdoc/>
        public DbSet<Clothe> Clothes { get; set; }

        /// <inheritdoc/>
        public DbSet<Invoice> Invoices { get; set; }

        /// <inheritdoc/>
        public DbSet<Music> Musics { get; set; }

        /// <inheritdoc/>
        public DbSet<Order> Orders { get; set; }

        /// <inheritdoc/>
        public DbSet<Subscriber> Subscribers { get; set; }

        /// <inheritdoc/>
        public DbSet<Subscription> Subscriptions { get; set; }

        /// <inheritdoc/>
        public DbSet<Receipt> Receipts { get; set; }

        /// <inheritdoc/>
        public DbSet<TodoItem> TodoItems { get; set; }

        /// <inheritdoc/>
        public DbSet<TodoList> TodoLists { get; set; }

        /// <inheritdoc/>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        /// <summary>
        /// Adding more settings to the db context.
        /// </summary>
        /// <param name="builder">The model builder of the db context.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.ApplyConfiguration(new RoleClaimConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserClaimConfiguration());
            builder.ApplyConfiguration(new UserLoginConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new UserTokenConfiguration());

            builder.ApplyConfiguration(new CartConfiguration());
            builder.ApplyConfiguration(new ClotheConfiguration());
            builder.ApplyConfiguration(new InvoiceConfiguration());
            builder.ApplyConfiguration(new MusicConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new ReceiptConfiguration());
            builder.ApplyConfiguration(new SubscriberConfiguration());
            builder.ApplyConfiguration(new SubscriptionConfiguration());
            builder.ApplyConfiguration(new TodoItemConfiguration());
            builder.ApplyConfiguration(new TodoListConfiguration());
        }
    }
}

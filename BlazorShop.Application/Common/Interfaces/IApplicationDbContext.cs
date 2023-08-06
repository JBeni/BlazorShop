// <copyright file="IApplicationDbContext.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Interfaces
{
    /// <summary>
    /// ApplicationDbContext is the entity framework database context for the application.
    /// </summary>
    public interface IApplicationDbContext
    {
        /// <summary>
        /// Gets or sets the <see cref="Cart"/> set.
        /// </summary>
        DbSet<Cart> Carts { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Clothe"/> set.
        /// </summary>
        DbSet<Clothe> Clothes { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Invoice"/> set.
        /// </summary>
        DbSet<Invoice> Invoices { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Music"/> set.
        /// </summary>
        DbSet<Music> Musics { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Order"/> set.
        /// </summary>
        DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Subscriber"/> set.
        /// </summary>
        DbSet<Subscriber> Subscribers { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Subscription"/> set.
        /// </summary>
        DbSet<Subscription> Subscriptions { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Receipt"/> set.
        /// </summary>
        DbSet<Receipt> Receipts { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="TodoItem"/> set.
        /// </summary>
        DbSet<TodoItem> TodoItems { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="TodoList"/> set.
        /// </summary>
        DbSet<TodoList> TodoLists { get; set; }

        /// <summary>
        /// Applying the chnages made to the application database context.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the operation.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

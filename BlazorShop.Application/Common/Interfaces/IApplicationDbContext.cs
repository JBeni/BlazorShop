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
        /// Gets the <see cref="Cart"/> set.
        /// </summary>
        DbSet<Cart> Carts { get; }

        /// <summary>
        /// Gets the <see cref="Clothe"/> set.
        /// </summary>
        DbSet<Clothe> Clothes { get; }

        /// <summary>
        /// Gets the <see cref="Invoice"/> set.
        /// </summary>
        DbSet<Invoice> Invoices { get; }

        /// <summary>
        /// Gets the <see cref="Music"/> set.
        /// </summary>
        DbSet<Music> Musics { get; }

        /// <summary>
        /// Gets the <see cref="Order"/> set.
        /// </summary>
        DbSet<Order> Orders { get; }

        /// <summary>
        /// Gets the <see cref="Subscriber"/> set.
        /// </summary>
        DbSet<Subscriber> Subscribers { get; }

        /// <summary>
        /// Gets the <see cref="Subscription"/> set.
        /// </summary>
        DbSet<Subscription> Subscriptions { get; }

        /// <summary>
        /// Gets the <see cref="Receipt"/> set.
        /// </summary>
        DbSet<Receipt> Receipts { get; }

        /// <summary>
        /// Gets the <see cref="TodoItem"/> set.
        /// </summary>
        DbSet<TodoItem> TodoItems { get; }

        /// <summary>
        /// Gets the <see cref="TodoList"/> set.
        /// </summary>
        DbSet<TodoList> TodoLists { get; }

        /// <summary>
        /// Gets the <see cref="CustomClaim"/> set.
        /// </summary>
        DbSet<CustomClaim> CustomClaims { get; }

        /// <summary>
        /// Applying the chnages made to the application database context.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the operation.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

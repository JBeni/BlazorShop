﻿namespace BlazorShop.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Cart> Carts { get; set; }
        DbSet<Clothe> Clothes { get; set; }
        DbSet<Music> Musics { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Subscriber> Subscribers { get; set; }
        DbSet<Subscription> Subscriptions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

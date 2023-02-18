// <copyright file="MediatorExtensions.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using MediatR;

namespace BlazorShop.Infrastructure.Common
{
    /// <summary>
    /// A mediator extensions.
    /// </summary>
    public static class MediatorExtensions
    {
        /// <summary>
        /// Dispatch Domain Events.
        /// </summary>
        /// <param name="mediator">Gets an instance of <see cref="IMediator"/>.</param>
        /// <param name="context">Gets an instance of <see cref="ApplicationDbContext"/>.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public static async Task DispatchDomainEvents(this IMediator mediator, ApplicationDbContext context)
        {
            var entities = context.ChangeTracker
                .Entries<EntityBase>()
                .Where(e => e.Entity.DomainEvents.Any())
                .Select(e => e.Entity);

            var domainEvents = entities
                .SelectMany(e => e.DomainEvents)
                .ToList();

            entities.ToList().ForEach(e => e.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent);
            }
        }
    }
}

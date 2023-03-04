// <copyright file="EntityBase.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorShop.Domain.Common
{
    /// <summary>
    /// A template for creating IDs.
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// The domain events.
        /// </summary>
        private readonly List<BaseEvent> domainEvents = new ();

        /// <summary>
        /// Gets or sets The id of the entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets the readonly collection of domain events.
        /// </summary>
        [NotMapped]
        public IReadOnlyCollection<BaseEvent> DomainEvents => this.domainEvents.AsReadOnly();

        /// <summary>
        /// Add an event to the domain.
        /// </summary>
        /// <param name="domainEvent">The domain event.</param>
        public void AddDomainEvent(BaseEvent domainEvent)
        {
            this.domainEvents.Add(domainEvent);
        }

        /// <summary>
        /// Remove an event to the domain.
        /// </summary>
        /// <param name="domainEvent">The domain event.</param>
        public void RemoveDomainEvent(BaseEvent domainEvent)
        {
            this.domainEvents.Remove(domainEvent);
        }

        /// <summary>
        /// Clear the domain events.
        /// </summary>
        public void ClearDomainEvents()
        {
            this.domainEvents.Clear();
        }
    }
}

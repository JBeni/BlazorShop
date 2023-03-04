// <copyright file="BaseEvent.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using MediatR;

namespace BlazorShop.Domain.Common
{
    /// <summary>
    /// A base event.
    /// </summary>
    public abstract class BaseEvent : INotification
    {
    }
}

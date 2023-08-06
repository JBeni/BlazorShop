﻿// <copyright file="DateTimeService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Services
{
    /// <summary>
    /// An implementation of <see cref="IDateTimeService"/>.
    /// </summary>
    public class DateTimeService : IDateTimeService
    {
        /// <summary>
        /// Gets the current time.
        /// </summary>
        public DateTime Now => DateTime.Now;
    }
}

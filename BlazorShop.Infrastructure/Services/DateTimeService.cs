// <copyright file="DateTimeService.cs" author="Beniamin Jitca">
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
        /// .
        /// </summary>
        public DateTime Now => DateTime.Now;
    }
}

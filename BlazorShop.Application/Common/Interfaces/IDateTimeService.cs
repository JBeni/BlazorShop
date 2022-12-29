// <copyright file="IDateTimeService.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Interfaces
{
    /// <summary>
    /// A service for handling the Datetime.
    /// </summary>
    public interface IDateTimeService
    {
        /// <summary>
        /// Gets the current Datetime.
        /// </summary>
        DateTime Now { get; }
    }
}

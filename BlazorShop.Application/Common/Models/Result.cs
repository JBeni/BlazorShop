// <copyright file="Result.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Models
{
    /// <summary>
    /// A generic model to return the results.
    /// </summary>
    /// <typeparam name="T">A generic type.</typeparam>
    public class Result<T>
        where T : class
    {
        /// <summary>
        /// Gets or sets a value indicating whether the request was successfully or not.
        /// </summary>
        public bool Successful { get; set; } = false;

        /// <summary>
        /// Gets or sets The error message if the request is not successful.
        /// </summary>
        public string? Error { get; set; } = null;

        /// <summary>
        /// Gets or sets A single item containing the data.
        /// </summary>
        public T? Item { get; set; } = null;

        /// <summary>
        /// Gets or sets A list of items containing the data.
        /// </summary>
        public List<T>? Items { get; set; } = null;
    }
}

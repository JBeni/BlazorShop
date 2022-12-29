// <copyright file="Result.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Models
{
    /// <summary>
    /// A generic model to return the results.
    /// </summary>
    public class Result<T> where T : class
    {
        /// <summary>
        /// A value indicating whether the request was successfully or not.
        /// </summary>
        public bool Successful { get; set; } = false;

        /// <summary>
        /// The error message if the request is not successful.
        /// </summary>
        public string? Error { get; set; } = null;

        /// <summary>
        /// A single item containing the data.
        /// </summary>
        public T? Item { get; set; } = null;

        /// <summary>
        /// A list of items containing the data.
        /// </summary>
        public List<T>? Items { get; set; } = null;
    }
}

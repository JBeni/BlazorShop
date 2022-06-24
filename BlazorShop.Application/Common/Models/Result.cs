// <copyright file="Result.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Models
{
    public class Result<T> where T : class
    {
        /// <summary>
        /// .
        /// </summary>
        public bool Successful { get; set; } = false;

        /// <summary>
        /// .
        /// </summary>
        public string? Error { get; set; } = null;

        /// <summary>
        /// .
        /// </summary>
        public T? Item { get; set; } = null;

        /// <summary>
        /// .
        /// </summary>
        public List<T>? Items { get; set; } = null;
    }
}

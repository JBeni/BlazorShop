// <copyright file="PaginatedList.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Models
{
    /// <summary>
    /// A model for returning results in pages.
    /// </summary>
    /// <typeparam name="T">The type of the class.</typeparam>
    public class PaginatedList<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedList{T}"/> class.
        /// </summary>
        /// <param name="items">The list of items.</param>
        /// <param name="count">The size of the list.</param>
        /// <param name="pageNumber">The number of the page.</param>
        /// <param name="pageSize">The size of the page.</param>
        public PaginatedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.TotalCount = count;
            this.Items = items;
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        public List<T> Items { get; }

        /// <summary>
        /// Gets the page number.
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// Gets the total pages.
        /// </summary>
        public int TotalPages { get; }

        /// <summary>
        /// Gets the total count.
        /// </summary>
        public int TotalCount { get; }

        /// <summary>
        /// Gets a value indicating whether if has a previous page.
        /// </summary>
        public bool HasPreviousPage => this.PageNumber > 1;

        /// <summary>
        /// Gets a value indicating whether if has a next page.
        /// </summary>
        public bool HasNextPage => this.PageNumber < this.TotalPages;

        /// <summary>
        /// Create a paginated list.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }
}

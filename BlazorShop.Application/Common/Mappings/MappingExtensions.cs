// <copyright file="MappingExtensions.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Mappings
{
    /// <summary>
    /// A custom mapping extension service.
    /// </summary>
    public static class MappingExtensions
    {
        /// <summary>
        /// Converting a list of object to a certain type of list of objects.
        /// </summary>
        /// <typeparam name="TDestination">The type to convert the list to.</typeparam>
        /// <param name="queryable">The query to be mapped.</param>
        /// <param name="configuration">The mapping configuration to apply on.</param>
        /// <returns>The list converted to a new type.</returns>
        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, AutoMapper.IConfigurationProvider configuration)
            => queryable.ProjectTo<TDestination>(configuration).ToListAsync();

        /// <summary>
        /// Converting a list of object to a certain type of list of objects.
        /// </summary>
        /// <typeparam name="TDestination">The type to convert the list to.</typeparam>
        /// <param name="queryable">The query to be mapped.</param>
        /// <param name="pageNumber">The number of page.</param>
        /// <param name="pageSize">The size of page.</param>
        /// <returns>The list converted to a paginated list.</returns>
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize)
            where TDestination : class
            => PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);
    }
}

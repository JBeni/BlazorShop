// <copyright file="MappingExtensions.cs" author="Beniamin Jitca">
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
        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, AutoMapper.IConfigurationProvider configuration)
            => queryable.ProjectTo<TDestination>(configuration).ToListAsync();
    }
}

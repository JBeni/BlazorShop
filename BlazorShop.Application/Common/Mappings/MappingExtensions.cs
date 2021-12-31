namespace BlazorShop.Application.Common.Mappings
{
    public static class MappingExtensions
    {
        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration)
            => queryable.ProjectTo<TDestination>(configuration).ToListAsync();
    }
}

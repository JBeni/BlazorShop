namespace BlazorShop.Application.Queries.CategoryQuery
{
    public class GetCategoryByIdQuery : IRequest<CategoryResponse>
    {
        public int Id { get; set; }
    }
}

namespace BlazorShop.Application.Queries.ProductQuery
{
    public class GetProductByIdQuery : IRequest<ProductResponse>
    {
        public int Id { get; set; }
    }
}

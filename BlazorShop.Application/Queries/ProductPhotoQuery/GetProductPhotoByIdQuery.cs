namespace BlazorShop.Application.Queries.ProductPhotoQuery
{
    public class GetProductPhotoByIdQuery : IRequest<ProductPhotoResponse>
    {
        public int Id { get; set; }
    }
}

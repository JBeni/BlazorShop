namespace BlazorShop.Application.Queries.CartQuery
{
    public class GetCartByIdQuery : IRequest<CartResponse>
    {
        public int Id { get; set; }
    }
}

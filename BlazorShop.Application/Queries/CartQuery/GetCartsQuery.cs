namespace BlazorShop.Application.Queries.CartQuery
{
    public class GetCartsQuery : IRequest<List<CartResponse>>
    {
        public int UserId { get; set; }
    }
}

namespace BlazorShop.Application.Queries.CartQuery
{
    public class GetCartsQuery : IRequest<Result<CartResponse>>
    {
        public int UserId { get; set; }
    }
}

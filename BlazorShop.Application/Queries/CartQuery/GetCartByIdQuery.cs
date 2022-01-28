namespace BlazorShop.Application.Queries.CartQuery
{
    public class GetCartByIdQuery : IRequest<Result<CartResponse>>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}

namespace BlazorShop.Application.Queries.CartQuery
{
    public class GetCartsQuery : IRequest<Result<CartResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int UserId { get; set; }
    }
}

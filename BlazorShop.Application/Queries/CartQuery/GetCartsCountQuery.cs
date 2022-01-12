namespace BlazorShop.Application.Queries.CartQuery
{
    public class GetCartsCountQuery : IRequest<int>
    {
        public int UserId { get; set; }
    }
}

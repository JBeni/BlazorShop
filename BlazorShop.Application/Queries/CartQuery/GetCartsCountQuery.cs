namespace BlazorShop.Application.Queries.CartQuery
{
    public class GetCartsCountQuery : IRequest<int>
    {
        /// <summary>
        /// .
        /// </summary>
        public int UserId { get; set; }
    }
}

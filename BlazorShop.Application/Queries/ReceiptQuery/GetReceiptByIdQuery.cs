namespace BlazorShop.Application.Queries.ReceiptQuery
{
    public class GetReceiptByIdQuery : IRequest<Result<ReceiptResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string UserEmail { get; set; }
    }
}

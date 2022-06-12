namespace BlazorShop.Application.Queries.ReceiptQuery
{
    public class GetReceiptsQuery : IRequest<Result<ReceiptResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public string UserEmail { get; set; }
    }
}

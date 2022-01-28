namespace BlazorShop.Application.Queries.ReceiptQuery
{
    public class GetReceiptsQuery : IRequest<Result<ReceiptResponse>>
    {
        public string UserEmail { get; set; }
    }
}

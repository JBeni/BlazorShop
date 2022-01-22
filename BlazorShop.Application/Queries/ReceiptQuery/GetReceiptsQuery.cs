namespace BlazorShop.Application.Queries.ReceiptQuery
{
    public class GetReceiptsQuery : IRequest<List<ReceiptResponse>>
    {
        public string UserEmail { get; set; }
    }
}

namespace BlazorShop.Application.Queries.ReceiptQuery
{
    public class GetReceiptByIdQuery : IRequest<ReceiptResponse>
    {
        public int Id { get; set; }
    }
}

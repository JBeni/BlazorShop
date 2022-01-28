namespace BlazorShop.Application.Queries.InvoiceQuery
{
    public class GetInvoiceByIdQuery : IRequest<Result<InvoiceResponse>>
    {
        public int Id { get; set; }
    }
}

namespace BlazorShop.Application.Queries.InvoiceQuery
{
    public class GetInvoiceByIdQuery : IRequest<InvoiceResponse>
    {
        public int Id { get; set; }
    }
}

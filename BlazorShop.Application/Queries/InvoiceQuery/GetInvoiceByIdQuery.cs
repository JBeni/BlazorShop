namespace BlazorShop.Application.Queries.InvoiceQuery
{
    public class GetInvoiceByIdQuery : IRequest<Result<InvoiceResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}

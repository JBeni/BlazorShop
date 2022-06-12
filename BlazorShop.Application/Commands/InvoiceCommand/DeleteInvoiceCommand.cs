namespace BlazorShop.Application.Commands.InvoiceCommand
{
    public class DeleteInvoiceCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}

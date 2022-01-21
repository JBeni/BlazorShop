namespace BlazorShop.Application.Commands.InvoiceCommand
{
    public class DeleteInvoiceCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
    }
}

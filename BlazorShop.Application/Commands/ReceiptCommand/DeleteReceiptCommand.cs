namespace BlazorShop.Application.Commands.ReceiptCommand
{
    public class DeleteReceiptCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
    }
}

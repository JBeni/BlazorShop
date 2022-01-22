namespace BlazorShop.Application.Commands.ReceiptCommand
{
    public class CreateReceiptCommand : IRequest<RequestResponse>
    {
        public string UserEmail { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string ReceiptName { get; set; }
        public string ReceiptUrl { get; set; }
    }
}

namespace BlazorShop.Application.Commands.ReceiptCommand
{
    public class UpdateReceiptCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string ReceiptName { get; set; }
        public string ReceiptUrl { get; set; }
    }
}

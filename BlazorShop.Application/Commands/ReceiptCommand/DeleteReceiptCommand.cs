namespace BlazorShop.Application.Commands.ReceiptCommand
{
    public class DeleteReceiptCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}

namespace BlazorShop.Application.Commands.InvoiceCommand
{
    public class UpdateInvoiceCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public int AmountSubTotal { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public int AmountTotal { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public int Quantity { get; set; }
    }
}

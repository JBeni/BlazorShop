namespace BlazorShop.Application.Commands.OrderCommand
{
    public class CreateOrderCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string LineItems { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public int AmountTotal { get; set; }
    }
}

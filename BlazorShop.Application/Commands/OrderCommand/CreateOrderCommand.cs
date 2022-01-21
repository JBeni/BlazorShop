namespace BlazorShop.Application.Commands.OrderCommand
{
    public class CreateOrderCommand : IRequest<RequestResponse>
    {
        public string UserEmail { get; set; }
        public DateTime OrderDate { get; set; }
        public string LineItems { get; set; }
        public int AmountTotal { get; set; }

    }
}

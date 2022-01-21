namespace BlazorShop.Application.Commands.OrderCommand
{
    public class CreateOrderCommand : IRequest<RequestResponse>
    {
        public string UserEmail { get; set; }
        public string Name { get; set; }
        public int AmountSubTotal { get; set; }
        public int AmountTotal { get; set; }
        public int Quantity { get; set; }
    }
}

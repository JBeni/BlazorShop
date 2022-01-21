namespace BlazorShop.Application.Commands.OrderCommand
{
    public class UpdateOrderCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string Name { get; set; }
        public int AmountSubTotal { get; set; }
        public int AmountTotal { get; set; }
        public int Quantity { get; set; }
    }
}
